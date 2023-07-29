using Application.ADTO;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;

namespace Domain.Services
{
    public class LoginCacheService : ILoginCacheService
    {
        private readonly ILoginCacheRepository _loginCacheRepository;

        public LoginCacheService(ILoginCacheRepository loginCacheRepository)
        {
            _loginCacheRepository = loginCacheRepository;
        }

        public async Task<LoginCache> Inserir(LoginCache loginCache) => await _loginCacheRepository.Insert(loginCache);

        public async Task<LoginCache> GetUserLoginByUserName(string userName) => await _loginCacheRepository.GetUserLoginByUserName(userName);

        public async Task<LoginCache> GetUserByToken(string token) => await _loginCacheRepository.GetUserByToken(token);

        public async Task<bool> DeleteUserByToken(string token) => await _loginCacheRepository.DeleteUserByToken(token);
    }
}
