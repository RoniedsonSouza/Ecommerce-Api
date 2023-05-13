using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BatalhaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BatalhaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarBatalha(AdicionarBatalhaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
