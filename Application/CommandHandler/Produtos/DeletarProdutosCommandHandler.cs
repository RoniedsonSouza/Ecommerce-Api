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
    public class DeletarProdutosCommandHandler : IRequestHandler<DeletarProdutoCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        public DeletarProdutosCommandHandler(IMediator mediator, IRepository<Produto> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<bool> Handle(DeletarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produtoId = request.ProdutoId;

            try
            {
                return await _repository.Delete(produtoId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao Deletar Produto!");
            }

        }
    }
}
