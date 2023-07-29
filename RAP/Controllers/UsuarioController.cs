using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RAP.Extensions;

namespace RAP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : RAPControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IMediator mediator, IUsuarioService usuarioService)
        {
            _mediator = mediator;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUserByNameOrVulgo([FromQuery] string? userName)
        {
            var usuario = await _usuarioService.GetUsuarioByNameOrVulgo(userName);
            return Ok(usuario);
        }
    }
}
