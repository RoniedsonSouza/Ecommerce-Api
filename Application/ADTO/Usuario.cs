using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.ADTO
{
    public class Usuario : IdentityUser<int>
    {
        [Column(TypeName = "nvarchar(150)")]
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public byte[]? FotoUsuario { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual List<UsuarioRoles> UserRoles { get; set; }
        public virtual List<ParticipantesOrganizacao> ParticipantesOrganizacao { get; set; }
        public virtual List<ParticipantesBatalha> ParticipantesBatalha { get; set; }
        public virtual List<ParticipantesEvento> ParticipantesEvento { get; set; }
        public virtual List<ConvidadosEvento> ConvidadosEvento { get; set; }
    }
}