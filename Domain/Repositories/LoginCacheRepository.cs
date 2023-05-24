using Application.ADTO;
using Application.Interfaces.Repository;
using Application.Repositories;
using Dapper;

namespace Domain.Repositories
{
    public class LoginCacheRepository : Repository<LoginCache>, ILoginCacheRepository
    {
        private readonly ApplicationDbContext _context;
        public LoginCacheRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<LoginCache> GetUserLoginByUserName(string userName)
        {
            return await _context.Connection.QueryFirstOrDefaultAsync<LoginCache>("SELECT TOP(1) * FROM LoginCache WHERE UserName = @UserName", new
            {
                UserName = userName
            });
        }

        public async Task<LoginCache> GetUserByToken(string token)
        {
            return await _context.Connection.QuerySingleAsync<LoginCache>("SELECT TOP(1) * FROM LoginCache WHERE TOKEN = @Token", new
            {
                Token = token
            });
        }

        public async Task<bool> DeleteUserByToken(string token)
        {
            var usuarioDeslogado = await _context.Connection.ExecuteAsync("DELETE LoginCache WHERE TOKEN = @Token", new
            {
                Token = token
            });

            return usuarioDeslogado == 1 ? true : false;
        }
    }
}
