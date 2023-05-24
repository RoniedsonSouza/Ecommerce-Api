using Application.ADTO;
using MediatR;

namespace Application.Filters
{
    public class FilterBatalhaCommand : IRequest<List<Batalha>>
    {
        public DateTime? DataBatalha { get; set; }
    }
}
