using System.ComponentModel.DataAnnotations;

namespace Application.ADTO
{
    public class TipoParticipanteBatalha
    {
        public string NomeTipo { get; set; }
        [Key]
        public int Tipo { get; set; }
        public virtual List<ParticipantesBatalha> ParticipantesBatalha { get; set; }
        public virtual List<ParticipantesEvento> ParticipantesEvento { get; set; }
    }
}
