using Application.ADTO;

namespace Application.Interfaces.Services
{
    public interface IBatalhaService
    {
        Task<Batalha> GetBatalhaById(Guid id);
    }
}