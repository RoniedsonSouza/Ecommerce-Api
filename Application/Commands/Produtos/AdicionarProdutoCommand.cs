using Application.ADTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Produtos
{
    public class AdicionarProdutoCommand : IRequest<Produto>
    {
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public int? Quantidade { get; set; }
        public double? Preco { get; set; }
        public bool Destaque { get; set; }
        public string Descricao { get; set; }
    }
}
