using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.ADTO
{
    public class TipoChaveBatalha
    {
        [Key]
        public int Chave { get; set; }
        public string TipoChave { get; set; }
        public virtual List<Batalha> Batalhas { get; set; }
    }
}
