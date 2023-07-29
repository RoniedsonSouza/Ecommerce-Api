using Application.ADTO;
using Application.Interfaces.Repository;
using Dapper;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetUserByName(string? userName)
        {
            var sql = @$"SELECT * FROM AspNetUsers WHERE 1 = 1 ";

            if (userName != null)
            {
                sql += $"AND Nome LIKE '%{userName}%' OR Apelido LIKE '%{userName}%'";
            }

            var usuarios = await _context.Connection.QueryAsync<Usuario>(sql);

            return usuarios.ToList();
        }
    }
}
