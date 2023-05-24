using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADTO
{
    public class ImagensBatalha
    {
        public Guid Id { get; set; }
        public Guid IdBatalha { get; set; }
        public byte[] Imagem { get; set; }
        public virtual Batalha Batalha { get; set; }
    }
}
