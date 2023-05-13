using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADTO
{
    public class ParticipantesEvento
    {
        [Key]
        public Guid IdParticipanteEvento { get; set; }
        public Guid IdEvento { get; set; }
        public int IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public byte[]? FotoParticipante { get; set; }
        public int Tipo { get; set; }
        public int Ranking { get; set; }
        public int Votos { get; set; }
        public virtual TipoParticipanteBatalha TipoParticipante { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Evento Batalha { get; set; }
    }
}
