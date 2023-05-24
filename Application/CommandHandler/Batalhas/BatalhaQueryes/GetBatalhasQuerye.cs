using Application.ADTO;
using Application.Filters;
using Application.Interfaces.Repository;
using MediatR;

namespace Application.CommandHandler.Batalhas.BatalhaQueryes
{
    public class GetBatalhasQuerye : IRequestHandler<FilterBatalhaCommand, List<Batalha>>
    {
        private readonly IMediator _mediator;
        private readonly IBatalhaRepository _batalhaRepository;
        public GetBatalhasQuerye(IMediator mediator, IBatalhaRepository repository)
        {
            _mediator = mediator;
            _batalhaRepository = repository;
        }
        public async Task<List<Batalha>> Handle(FilterBatalhaCommand filter, CancellationToken cancellationToken)
        {
            return await _batalhaRepository.GetBatalhasFilter(filter);
        }
    }

}
