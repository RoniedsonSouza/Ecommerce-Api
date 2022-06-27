using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTO
{
    public class UsuarioRoles : IdentityUserRole<int>
    {
        public Usuario Usuario { get; set; }
        public Role Role { get; set; }
    }
}
