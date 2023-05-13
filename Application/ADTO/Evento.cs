using System.ComponentModel.DataAnnotations;

namespace Application.ADTO
{
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; }
        public Guid? IdBatalha { get; set; }
        public int? Edicao { get; set; }
        public DateTime DataEvento { get; set; }
        public string? Rua { get; set; }
        public int? Numero { get; set; }
        public string? Cep { get; set; }
        public string? Referencia { get; set; }
        public virtual List<ParticipantesEvento> ParticipantesEvento { get; set; }
        public virtual List<ConvidadosEvento> ConvidadosEvento { get; set; }
        public virtual Batalha Batalha { get; set; }
    }
}
