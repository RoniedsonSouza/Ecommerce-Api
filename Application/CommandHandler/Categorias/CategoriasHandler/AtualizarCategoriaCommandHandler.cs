using Application.ADTO;
using Application.Commands.Categoria;
using Application.Interfaces;
using MediatR;

namespace Application.CommandHandler.Categorias.CategoriasHandler
{
    public class AtualizarCategoriaCommandHandler : IRequestHandler<AtualizarCategoriaCommand, Categoria>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Categoria> _repository;
        public AtualizarCategoriaCommandHandler(IMediator mediator, IRepository<Categoria> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Categoria> Handle(AtualizarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Categoria
            {
                Name = request.Name,
                Description = request.Description,
            };

            try
            {
                return await _repository.Update(categoria);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao Atualizar Categoria!");
            }

        }
    }
}
