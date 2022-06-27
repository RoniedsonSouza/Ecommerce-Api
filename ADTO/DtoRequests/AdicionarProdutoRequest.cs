using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTO.DtoRequests
{
    public class AdicionarProdutoRequest
    {
        public int? CategoriaId { get; set; }
        public string Nome { get; set; }
        public int? Quantidade { get; set; }
        public double? Preco { get; set; }
        public bool Destaque { get; set; }
        public string Descricao { get; set; }
    }
}
