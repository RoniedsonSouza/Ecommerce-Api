using Application.ADTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBatalhaRepository : IRepository<Batalha>
    {
        Task<List<ParticipantesBatalha>> InsereParticipantes(List<ParticipantesBatalha> participantes);
    }
}
