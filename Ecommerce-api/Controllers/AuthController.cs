using Application.ADTO;
using Application.ADTO.DtoRequests;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration configuration,
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IMapper mapper)
        {
            _configuration = configuration;
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
            var user = await _userManager.FindByNameAsync(usuario.UserName);
            var result = await _signInManager.CheckPasswordSignInAsync(user, usuario.Password, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.Users
                    .FirstOrDefaultAsync(x => x.NormalizedUserName == usuario.UserName.ToUpper());

                var userToReturn = _mapper.Map<LoginRequest>(appUser);

                return Ok(new
                {
                    token = GenerateJWToken(appUser).Result,
                    user = userToReturn
                });
            }
            return Unauthorized();
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
            var result = await _userManager.CreateAsync(user, usuario.Password);
            var userToReturn = _mapper.Map<UsuarioRequest>(user);

            if (result.Succeeded)
                return Created("GetUser", userToReturn);

            return BadRequest(result.Errors);
        }
    }
}
