using Application.ADTO;
using Application.Commands.Filters;
using Application.Commands.Organizacoes;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RAP.Extensions;

namespace RAP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizacaoController : RAPControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrganizacaoService _organizacaoService;
        private readonly ILoginCacheService _loginCacheService;
        public OrganizacaoController(IMediator mediator, ILoginCacheService loginCacheService, IOrganizacaoService organizacaoService)
        {
            _mediator = mediator;
            _loginCacheService = loginCacheService;
            _organizacaoService = organizacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterOrganizacoes([FromQuery] FilterOrganizacaoCommand filter)
        {
            var response = await _organizacaoService.ObterOrganizacaoPorFiltro(filter);
            return Ok(response);
        }

        [HttpGet("ObterOrganizacaoUsuario")]
        public async Task<IActionResult> ObterOrganizacaoUsuario()
        {
            var usuario = await _loginCacheService.GetUserByToken(token);
            var response = await _organizacaoService.ObterOrganizacoesUsuarioAsync(usuario.IdUsuario);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CriarOrganizacao(AdicionarOrganizacaoCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
