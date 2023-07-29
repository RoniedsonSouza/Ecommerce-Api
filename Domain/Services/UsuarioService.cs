using Application.ADTO;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;

namespace Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> GetUsuarioByNameOrVulgo(string? userName) => await _usuarioRepository.GetUserByName(userName);
    }
}
