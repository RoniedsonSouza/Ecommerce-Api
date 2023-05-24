using Application.ADTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface ILoginCacheRepository : IRepository<LoginCache>
    {
        Task<LoginCache> GetUserLoginByUserName(string userName);
        Task<LoginCache> GetUserByToken(string token);
        Task<bool> DeleteUserByToken(string token);
    }
}
