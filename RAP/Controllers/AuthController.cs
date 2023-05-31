using Application.ADTO;
using Application.ADTO.DtoRequests;
using Application.Interfaces.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RAP.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RAP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : RAPControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginCacheRepository _loginCacheRepository;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration configuration,
            ILoginCacheRepository loginCacheRepository,
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IMapper mapper)
        {
            _configuration = configuration;
            _loginCacheRepository = loginCacheRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string userName)
        {
            return Ok(await _userManager.FindByNameAsync(userName));
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest usuario)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(usuario.UserName);
                var result = await _signInManager.CheckPasswordSignInAsync(user, usuario.Password, false);
                var userLogged = await _loginCacheRepository.GetUserLoginByUserName(usuario.UserName);

                if (result.Succeeded)
                {
                    var appUser = await _userManager.Users
                        .FirstOrDefaultAsync(x => x.NormalizedUserName == usuario.UserName.ToUpper());
                    var generatedToken = GenerateJWToken(appUser).Result;

                    var criarLoginCache = await _loginCacheRepository.Insert(new LoginCache
                    {
                        IdUsuario = user.Id,
                        UserName = user.UserName,
                        Nome = user.Nome,
                        Token = generatedToken,
                        Ativo = true
                    });

                    var userToReturn = _mapper.Map<LoginRequest>(appUser);

                    return Ok(new
                    {
                        token = generatedToken,
                        user = userToReturn
                    });
                }
                else if (userLogged != null)
                {
                    return Ok(new { Message = "Usuário já está logado!" });
                }
                else
                {
                    return Ok(new { Message = "Usuário ou senha incorretos!" });
                }
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        private async Task<string> GenerateJWToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.UserName)
            };

            var roles = await _userManager.GetRolesAsync(usuario);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_configuration
                .GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UsuarioRequest usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);
            var userExists = await _userManager.FindByNameAsync(usuario.UserName);
            if (userExists == null)
            {
                var result = await _userManager.CreateAsync(user, usuario.Password);
                var userToReturn = _mapper.Map<UsuarioRequest>(user);

                if (result.Succeeded)
                    return Created("GetUser", userToReturn);

                return BadRequest(result.Errors);
            }
            else
            {
                return Ok(new { userExists = true });
            }
        }

        [HttpPost("DeslogarUsuario")]
        public async Task<IActionResult> Deslogar()
        {
            var deslogado = await _loginCacheRepository.DeleteUserByToken(token);
            return deslogado ? Ok() : BadRequest();
        }
    }
}
