using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADTO
{
    public class ParticipantesOrganizacao
    {
        public Guid Id { get; set; }
        public Guid IdOrganizacao { get; set; }
        public int IdUsuarioParticipante { get; set; }
        public virtual Organizacao Organizacao { get; set; }
        public virtual Usuario UsuarioParticipante { get; set; }
    }
}
