using Application.ADTO;

namespace Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetUsuarioByNameOrVulgo(string? userName);
    }
}