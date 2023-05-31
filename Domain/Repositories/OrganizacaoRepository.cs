using Application.ADTO;
using Application.Interfaces.Repository;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class OrganizacaoRepository : Repository<Organizacao>, IOrganizacaoRepository
    {
        private readonly ApplicationDbContext _context;
        public OrganizacaoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
