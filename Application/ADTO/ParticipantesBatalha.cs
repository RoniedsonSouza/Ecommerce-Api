using System.ComponentModel.DataAnnotations;

namespace Application.ADTO
{
    public class ParticipantesBatalha
    {
        [Key]
        public Guid IdParticipanteBatalha { get; set; }
        public Guid IdBatalha { get; set; }
        public int IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public byte[]? FotoParticipante { get; set; }
        public int Tipo { get; set; }
        public int Ranking { get; set; }
        public int Votos { get; set; }
        public  virtual TipoParticipanteBatalha TipoParticipante { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Batalha Batalha { get; set; }
    }
}
