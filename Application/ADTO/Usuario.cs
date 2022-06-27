using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.ADTO
{
    public class Usuario : IdentityUser<int>
    {
        [Column(TypeName = "nvarchar(150)")]
        public string Nome { get; set; }
        public List<UsuarioRoles> UserRoles { get; set; }
    }
}