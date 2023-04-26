using Application.ADTO.DtoResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Categorias
{
    public class ObterCategoriaCommand : IRequest<IEnumerable<Application.ADTO.Categoria>>
    {
        public string Filter { get; set; }
    }
}
