using System.ComponentModel.DataAnnotations;

namespace Application.ADTO
{
    public class TipoChaveBatalha
    {
        [Key]
        public int Chave { get; set; }
        public string TipoChave { get; set; }
    }
}
