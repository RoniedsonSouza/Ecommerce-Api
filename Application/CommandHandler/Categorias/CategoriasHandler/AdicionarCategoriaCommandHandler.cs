using Application.ADTO;
using Application.ADTO.DtoRequests;
using Application.Commands.Categoria;
using Application.Commands.Categorias;
using Application.Interfaces;
using MediatR;

namespace Application.CommandHandler.Categorias.CategoriasHandler
{
    public class AdicionarCategoriaCommandHandler : IRequestHandler<AdicionarCategoriaCommand, Categoria>
    {
        private readonly IMediator _mediator;
        private readonly ICategoriaRepository _repository;
        public AdicionarCategoriaCommandHandler(IMediator mediator, ICategoriaRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Categoria> Handle(AdicionarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Categoria
            {
                Name = request.Name,
                Description = request.Description,
            };

            try
            {
                await _repository.Insert(categoria);
                return categoria;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao Adicionar Categoria!, Erro: " + ex);
            }

        }
    }
}
