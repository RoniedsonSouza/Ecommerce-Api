using Application.ADTO;
using Application.ADTO.DtoRequests;
using MediatR;

namespace Application.Commands.Batalhas
{
    public class AdicionarBatalhaCommand : DefaultModel, IRequest<Batalha>
    {
        public Guid? IdOrganizacao { get; set; }
        public string Titulo { get; set; }
        public int Edicao { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cep { get; set; }
        public string? Referencia { get; set; }
        public string? LatLong { get; set; }
        public DateTime DataBatalha { get; set; }
        public int? Chave { get; set; }
        public bool SorteioAutomatico { get; set; }
        public bool BatalhaPrivada { get; set; }
        public bool OcultarBatalha { get; set; }
        public bool GerarQRCode { get; set; }
        public int Likes { get; set; }
        public List<ParticipantesBatalhaRequest>? ParticipantesBatalha { get; set; }
        public List<ImagensBatalha>? ImagensBatalha { get; set; }
    }
}
