using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Categoria
{
    public class DeletarCategoriaCommand : IRequest<bool>
    {
        public int CategoryId { get; set; }
    }
}
