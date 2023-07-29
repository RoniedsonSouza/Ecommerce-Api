using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADTO
{
    public class ParticipantesOrganizacaoDTO
    {
        public Guid Id { get; set; }
        public Guid IdOrganizacao { get; set; }
        public int IdUsuarioParticipante { get; set; }
    }
}
