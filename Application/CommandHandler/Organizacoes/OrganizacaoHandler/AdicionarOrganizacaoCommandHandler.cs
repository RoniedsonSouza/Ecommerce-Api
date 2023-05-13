using Application.ADTO;
using Application.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.CommandHandler.Categorias.CategoriasHandler
{
    public class AdicionarOrganizacaoCommandHandler : IRequestHandler<AdicionarOrganizacaoCommand, Organizacao>
    {
        private readonly IMediator _mediator;
        private readonly IOrganizacaoRepository _repository;
        private readonly IParticipantesOrganizacaoRepository _participantesOrganizacaoRepository;
        public AdicionarOrganizacaoCommandHandler(IMediator mediator, IOrganizacaoRepository repository, IParticipantesOrganizacaoRepository participantesOrganizacaoRepository)
        {
            _mediator = mediator;
            _repository = repository;
            _participantesOrganizacaoRepository = participantesOrganizacaoRepository;
        }

        public async Task<Organizacao> Handle(AdicionarOrganizacaoCommand request, CancellationToken cancellationToken)
        {
            var organizacao = new Organizacao()
            {
                Nome = request.Nome,
                LogoOrganizacao = request.LogoOrganizacao,
                Rua = request.Rua,
                Cep = request.Cep,
                Referencia = request.Referencia,
                Youtube = request.Youtube,
                Twitch = request.Twitch,
                CNPJ = request.CNPJ
            };
            
            try
            {
                var listParticipantes = new List<ParticipantesOrganizacao>();
                var insertOrganization = await _repository.Insert(organizacao);

                foreach (var participantes in request.Participantes)
                {
                    listParticipantes.Add(new ParticipantesOrganizacao() { IdOrganizacao = insertOrganization.IdOrganizacao, IdUsuarioParticipante = participantes.IdUsuarioParticipante });
                }

                await _participantesOrganizacaoRepository.InsertRangeAsync(listParticipantes);
                organizacao.Participantes = listParticipantes;
                return organizacao;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao Criar Organização!, Erro: " + ex);
            }

        }
    }
}
