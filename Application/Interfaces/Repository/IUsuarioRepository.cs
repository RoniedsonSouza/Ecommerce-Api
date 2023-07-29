using Application.ADTO;

namespace Application.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetUserByName(string userName);
    }
}