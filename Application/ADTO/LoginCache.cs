using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADTO
{
    public class LoginCache : DefaultModel
    {
        [Key]
        public Guid Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool Ativo { get; set; }
    }
}
