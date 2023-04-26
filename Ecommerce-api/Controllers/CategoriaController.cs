using Application.ADTO;
using Application.Commands.Categoria;
using Application.Commands.Categorias;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new ObterCategoriaCommand());
            return Ok(response);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return Ok(await _repository.GetById(id));
        //}

        [HttpPost]
        public async Task<IActionResult> CriarCategoria(AdicionarCategoriaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCategoria(AtualizarCategoriaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCategoria(int id)
        {
            var obj = new DeletarCategoriaCommand { CategoryId = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}
