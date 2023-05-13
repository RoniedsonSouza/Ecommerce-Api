using Application.ADTO;
using Application.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizacaoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrganizacaoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarOrganizacao(AdicionarOrganizacaoCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
