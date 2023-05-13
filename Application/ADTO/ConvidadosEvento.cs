using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADTO
{
    public class ConvidadosEvento
    {
        [Key]
        public Guid IdConvidadoEvento { get; set; }
        public Guid IdEvento { get; set; }
        public int IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public byte[]? FotoConvidado { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Evento Evento { get; set; }
    }
}
