
namespace Application.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task<bool> Delete(object id);
    }
}