using Application.ADTO;
using MediatR;

namespace Application.Commands.Filters
{
    public class FilterBatalhaCommand : IRequest<List<Batalha>>
    {
        public DateTime? DataBatalha { get; set; }
    }
}
