using Application.ADTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Filters
{
    public class FilterOrganizacaoCommand : IRequest<List<Organizacao>>
    {
        public string? Nome { get; set; }
        public string? Rua { get; set; }
        public int? Numero { get; set; }
        public string? Cep { get; set; }
        public string? CNPJ { get; set; }
    }
}
