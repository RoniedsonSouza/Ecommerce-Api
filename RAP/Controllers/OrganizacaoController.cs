using Application.ADTO;
using Application.Commands.Organizacoes;
using Application.Interfaces;
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
        public OrganizacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarOrganizacao(AdicionarOrganizacaoCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
