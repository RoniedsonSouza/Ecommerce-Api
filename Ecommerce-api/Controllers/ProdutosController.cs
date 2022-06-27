using Application.ADTO.DtoRequests;
using Application.Produtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Insert([FromBody] AdicionarProdutoRequest request)
        {
            var command = new AdicionarProdutoCommand(request);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
