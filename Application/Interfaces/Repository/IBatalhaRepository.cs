using Application.ADTO;
using Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IBatalhaRepository : IRepository<Batalha>
    {
        Task<List<ParticipantesBatalha>> InsereParticipantes(List<ParticipantesBatalha> participantes);
        Task<List<Batalha>> GetBatalhasFilter(FilterBatalhaCommand filter);
    }
}
