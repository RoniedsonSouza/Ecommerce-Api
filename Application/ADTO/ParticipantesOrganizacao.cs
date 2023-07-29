namespace Application.ADTO
{
    public class ParticipantesOrganizacao : DefaultModel
    {
        public Guid Id { get; set; }
        public Guid IdOrganizacao { get; set; }
        public int IdUsuarioParticipante { get; set; }
        public virtual Organizacao Organizacao { get; set; }
        public virtual Usuario UsuarioParticipante { get; set; }
    }
}
