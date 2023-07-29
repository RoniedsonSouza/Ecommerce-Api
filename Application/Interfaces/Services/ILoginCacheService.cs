using Application.ADTO;

namespace Application.Interfaces.Services
{
    public interface ILoginCacheService
    {
        Task<LoginCache> Inserir(LoginCache loginCache);
        Task<bool> DeleteUserByToken(string token);
        Task<LoginCache> GetUserByToken(string token);
        Task<LoginCache> GetUserLoginByUserName(string userName);
    }
}