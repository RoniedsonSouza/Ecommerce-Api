using Application.ADTO;
using Application.Interfaces;
using Application.Repositories;

namespace Domain.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        private readonly ApplicationDbContext _context;
        public ProdutoRepository(ApplicationDbContext context) : base(context)
        {
            _context= context;
        }
    }
}
