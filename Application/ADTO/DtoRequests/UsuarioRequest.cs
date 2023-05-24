using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADTO.DtoRequests
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string? Apelido { get; set; }
        public byte[]? FotoUsuario { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
