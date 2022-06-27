using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTO
{
    public class ImagensProdutos
    {
        [Key]
        public int FotoID { get; set; }
        public byte[] Imagem { get; set; }
        public string ImageUrl { get; set; }
        public string ContentType { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
