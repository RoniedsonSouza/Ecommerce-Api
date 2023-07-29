using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validadores
{
    public static class Utils
    {
        public static bool EhNuloOuVazio(this string valor)
           => string.IsNullOrWhiteSpace(valor);
    }
}
