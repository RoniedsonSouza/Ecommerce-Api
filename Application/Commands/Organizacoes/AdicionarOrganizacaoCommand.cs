using Application.ADTO;
using Application.ADTO.DtoRequests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class AdicionarOrganizacaoCommand : DefaultModel, IRequest<Organizacao>
    {
        public string? Nome { get; set; }
        public byte[]? LogoOrganizacao { get; set; }
        public string? Rua { get; set; }
        public string? Cep { get; set; }
        public string? Referencia { get; set; }
        public string? Youtube { get; set; }
        public string? Twitch { get; set; }
        public string? CNPJ { get; set; }
        public List<ParticipantesOrganizacaoRequest> Participantes { get; set; } = new List<ParticipantesOrganizacaoRequest>();
    }
}
