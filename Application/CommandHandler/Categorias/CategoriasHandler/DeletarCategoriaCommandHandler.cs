using Application.ADTO;
using Application.Commands.Categoria;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandler.Categorias.CategoriasHandler
{
    public class DeletarCategoriaCommandHandler : IRequestHandler<DeletarCategoriaCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Categoria> _repository;
        public DeletarCategoriaCommandHandler(IMediator mediator, IRepository<Categoria> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<bool> Handle(DeletarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoriaId = request.CategoryId;

            try
            {
                return await _repository.Delete(categoriaId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao Deletar Categoria!");
            }

        }
    }
}
