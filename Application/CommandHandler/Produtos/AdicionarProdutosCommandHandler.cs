using Application.ADTO;
using Application.Commands;
using Application.Commands.Produtos;
using Application.Interfaces;
using MediatR;

namespace Application.CommandHandler.Produtos { 
    public class AdicionarProdutosCommandHandler : IRequestHandler<AdicionarProdutoCommand, Produto>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        public AdicionarProdutosCommandHandler(IMediator mediator, IRepository<Produto> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<Produto> Handle(AdicionarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto { 
                CategoryId = request.CategoryId,
                Name = request.Name,
                Quantidade = request.Quantidade,
                Preco = request.Preco, 
                Destaque = request.Destaque,
                Descricao = request.Descricao
            };

            try
            {
                return await _repository.Insert(produto);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao Adicionar Produto!");
            }

        }
    }
}
