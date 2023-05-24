using Application.ADTO;
using Application.Commands.Batalhas;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandler.Batalhas.BatalhaHandler
{
    public class EditarBatalhaCommandHandler : IRequestHandler<EditarBatalhaCommand, Batalha>
    {
        private readonly IMediator _mediator;
        private readonly IBatalhaRepository _batalhaRepository;

        public EditarBatalhaCommandHandler(IMediator mediator, IBatalhaRepository repository)
        {
            _mediator = mediator;
            _batalhaRepository = repository;
        }

        public async Task<Batalha> Handle(EditarBatalhaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var batalha = new Batalha()
                {
                    IdBatalha = request.IdBatalha,
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
                    GerarQRCode = request.GerarQRCode
                };

                await _batalhaRepository.Update(batalha);

                return batalha;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
