namespace Application.ADTO.DtoRequests
{
    public class ParticipantesBatalhaRequest
    {
        public Guid IdBatalha { get; set; }
        public int IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public byte[]? FotoParticipante { get; set; }
        public int Tipo { get; set; }
        public int Ranking { get; set; }
        public int Votos { get; set; }
        public int Grupo { get; set; }
        public int Posicao { get; set; }
        public bool Vencedor { get; set; }
    }
}
