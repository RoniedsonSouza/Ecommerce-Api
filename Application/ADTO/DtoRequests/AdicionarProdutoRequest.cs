using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADTO.DtoRequests
{
    public class AdicionarProdutoRequest
    {
        public int ProdutoId { get; set; }
        public int? CategoriaId { get; set; }
        public string Nome { get; set; }
        public int? Quantidade { get; set; }
        public double? Preco { get; set; }
        public bool Destaque { get; set; }
        public string Descricao { get; set; }
        public Categoria Categoria { get; set; }
    }
}
