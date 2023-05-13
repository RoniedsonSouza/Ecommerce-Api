using System.ComponentModel.DataAnnotations;

namespace Application.ADTO
{
    public class Organizacao : DefaultModel
    {
        [Key]
        public Guid IdOrganizacao { get; set; }
        public string? Nome { get; set; }
        public byte[]? LogoOrganizacao { get; set; }
        public string? Rua { get; set; }
        public int? Numero { get; set; }
        public string? Cep { get; set; }
        public string? Referencia { get; set; }
        public string? LatLong { get; set; }
        public string? Youtube { get; set; }
        public string? Twitch { get; set; }
        public string? CNPJ { get; set; }
        public int Likes { get; set; }
        public virtual List<ParticipantesOrganizacao> Participantes { get; set; }
        public virtual List<Batalha> Batalhas { get; set; }
    }
}
