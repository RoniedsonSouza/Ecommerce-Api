using Application.ADTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Produtos
{
    public class AtualizarProdutosCommand : IRequest<Produto>
    {
        public int ProdutoId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public int? Quantidade { get; set; }
        public double? Preco { get; set; }
        public bool Destaque { get; set; }
        public string Descricao { get; set; }
    }
}
