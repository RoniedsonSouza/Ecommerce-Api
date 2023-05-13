using Application.ADTO;
using Application.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.CommandHandler.Batalhas.BatalhaHandler
{
    public class AdicionarBatalhaCommandHandler : IRequestHandler<AdicionarBatalhaCommand, Batalha>
    {
        private readonly IMediator _mediator;
        private readonly IBatalhaRepository _batalhaRepository;

        public AdicionarBatalhaCommandHandler(IMediator mediator, IBatalhaRepository repository)
        {
            _mediator = mediator;
            _batalhaRepository = repository;
        }

        public async Task<Batalha> Handle(AdicionarBatalhaCommand request, CancellationToken cancellationToken)
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

            try
            {
                var listParticipantes = new List<ParticipantesBatalha>();
                var insertBatalha = await _batalhaRepository.Insert(batalha);

                if (request.ParticipantesBatalha?.Count > 0)
                {
                    foreach (var participante in request.ParticipantesBatalha)
                    {
                        var participanteBatalha = new ParticipantesBatalha()
                        {
                            IdBatalha = insertBatalha.IdBatalha,
                            IdUsuario = participante.IdUsuario,
                            Nome = participante.Nome,
                            Apelido = participante.Apelido,
                            FotoParticipante = participante.FotoParticipante,
                            Tipo = participante.Tipo
                        };

                        listParticipantes.Add(participanteBatalha);
                    }
                }

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
