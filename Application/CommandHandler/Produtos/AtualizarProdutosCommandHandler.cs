using Application.ADTO;
using Application.Commands.Produtos;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandler.Produtos
{
    public class AtualizarProdutosCommandHandler : IRequestHandler<AtualizarProdutosCommand, Produto>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        public AtualizarProdutosCommandHandler(IMediator mediator, IRepository<Produto> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<Produto> Handle(AtualizarProdutosCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Quantidade = request.Quantidade,
                Preco = request.Preco,
                Destaque = request.Destaque,
                Descricao = request.Descricao
            };

            try
            {
                return await _repository.Update(produto);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao Atualizar Produto!");
            }

        }
    }
}
