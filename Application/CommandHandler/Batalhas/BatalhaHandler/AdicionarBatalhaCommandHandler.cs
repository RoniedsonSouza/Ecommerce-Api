using Application.ADTO;
using Application.ADTO.DtoRequests;
using Application.Commands.Batalhas;
using Application.Interfaces.Repository;
using MediatR;

namespace Application.CommandHandler.Batalhas.BatalhaHandler
{
    public class AdicionarBatalhaCommandHandler : IRequestHandler<AdicionarBatalhaCommand, Batalha>
    {
        private readonly IMediator _mediator;
        private readonly IBatalhaRepository _batalhaRepository;
        private readonly IParticipantesOrganizacaoRepository _participantesOrganizacaoRepository;
        private readonly ILoginCacheRepository _loginCacheRepository;

        public AdicionarBatalhaCommandHandler(IMediator mediator, IBatalhaRepository repository, IParticipantesOrganizacaoRepository participantesOrganizacaoRepository, ILoginCacheRepository loginCacheRepository)
        {
            _mediator = mediator;
            _batalhaRepository = repository;
            _participantesOrganizacaoRepository = participantesOrganizacaoRepository;
            _loginCacheRepository = loginCacheRepository;
        }

        public async Task<Batalha> Handle(AdicionarBatalhaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var batalha = new Batalha()
                {
                    IdOrganizacao = request.IdOrganizacao,
                    Titulo = request.Titulo,
                    Edicao = request.Edicao,
                    Rua = request.Rua,
                    Numero = request.Numero,
                    Cep = request.Cep,
                    Referencia = request.Referencia,
                    LatLong = request.LatLong,
                    DataBatalha = request.DataBatalha,
                    Chave = request.Chave,
                    SorteioAutomatico = request.SorteioAutomatico,
                    BatalhaPrivada = request.BatalhaPrivada,
                    OcultarBatalha = request.OcultarBatalha,
                    GerarQRCode = request.GerarQRCode,
                    Likes = request.Likes
                };


                var listParticipantes = new List<ParticipantesBatalha>();
                var listMcs = new List<ParticipantesBatalhaRequest>();
                var qtdParticipantes = request.ParticipantesBatalha != null ? request.ParticipantesBatalha.Count : 0;
                var grupo = 1;
                var index = 0;

                var insertBatalha = await _batalhaRepository.Insert(batalha);

                if (qtdParticipantes == 0)
                    return insertBatalha;

                foreach (var participante in request.ParticipantesBatalha)
                {
                    index++;

                    if (participante.Tipo == 3)
                        listMcs.Add(participante);

                    var participanteBatalha = new ParticipantesBatalha()
                    {
                        IdBatalha = insertBatalha.IdBatalha,
                        IdUsuario = participante.IdUsuario,
                        Nome = participante.Nome,
                        Apelido = participante.Apelido,
                        FotoParticipante = participante.FotoParticipante,
                        Tipo = participante.Tipo,
                        Grupo = grupo,
                        Posicao = participante.Posicao
                    };

                    listParticipantes.Add(participanteBatalha);

                    if (index % 2 == 0 && batalha.Chave == 1 && qtdParticipantes >= 6)
                        grupo++;

                    if (index % 4 == 0 && batalha.Chave == 2 && qtdParticipantes >= 8)
                        grupo++;

                    if (index % 6 == 0 && batalha.Chave == 3 && qtdParticipantes >= 12)
                        grupo++;
                }

                //if (listMcs.Count % 2 != 0)
                //    throw new InvalidOperationException("Número de Mcs Deve ser par!");

                await _batalhaRepository.InsereParticipantes(listParticipantes);
                insertBatalha.ParticipantesBatalha = listParticipantes;

                return insertBatalha;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao Criar Batalha!, Erro: " + ex);
            }

        }
    }
}
