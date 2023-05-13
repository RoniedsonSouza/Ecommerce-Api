using Application.ADTO;
using Application.Interfaces;
using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class ParticipanteOrganizacaoRepository : Repository<ParticipantesOrganizacao>, IParticipantesOrganizacaoRepository
    {
        private readonly ApplicationDbContext _context;
        public ParticipanteOrganizacaoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
