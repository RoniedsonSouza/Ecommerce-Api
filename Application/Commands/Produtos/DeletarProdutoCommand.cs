using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Produtos
{
    public class DeletarProdutoCommand : IRequest<bool>
    {
        public int ProdutoId { get; set; }
    }
}
