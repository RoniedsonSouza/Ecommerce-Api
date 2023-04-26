using Application.ADTO;
using Application.ADTO.DtoResponse;
using Application.Commands.Categorias;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandler.Categorias.CategoriasQueryes
{
    public class ObterCategoriasQuery : IRequestHandler<ObterCategoriaCommand, IEnumerable<Categoria>>
    {
        private readonly IMediator _mediator;
        private readonly ICategoriaRepository _repository;
        public ObterCategoriasQuery(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<Categoria>> Handle(ObterCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await _repository.GetAll();

                var result = categoria
                    .Where(x => x.Name.Contains(request.Filter))
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao Buscar Categorias!, Erro: " + ex);
            }

        }
    }
}
