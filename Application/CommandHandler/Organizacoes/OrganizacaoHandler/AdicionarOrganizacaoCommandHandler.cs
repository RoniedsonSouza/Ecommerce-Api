using Application.ADTO;
using Application.ADTO.DtoResponse;
using Application.Commands.Organizacoes;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;

namespace Application.CommandHandler.Organizacoes.OrganizacaoHandler
{
    public class AdicionarOrganizacaoCommandHandler : IRequestHandler<AdicionarOrganizacaoCommand, OrganizacaoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IOrganizacaoRepository _repository;
        private readonly IParticipantesOrganizacaoRepository _participantesOrganizacaoRepository;
        public AdicionarOrganizacaoCommandHandler(IMediator mediator, IOrganizacaoRepository repository, IParticipantesOrganizacaoRepository participantesOrganizacaoRepository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _participantesOrganizacaoRepository = participantesOrganizacaoRepository;
            _mapper = mapper;
        }

        public async Task<OrganizacaoResponse> Handle(AdicionarOrganizacaoCommand request, CancellationToken cancellationToken)
        {
            Organizacao organizacao = _mapper.Map<Organizacao>(request);

            try
            {
                await _repository.Insert(organizacao);
                OrganizacaoResponse response = _mapper.Map<OrganizacaoResponse>(organizacao);
                return response;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao Criar Organização!, Erro: " + ex);
            }

        }
    }
}
