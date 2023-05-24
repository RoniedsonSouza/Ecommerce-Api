namespace Application.Interfaces.Repository
{
    public interface IRepository<T>
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> Insert(T obj);
        Task InsertRangeAsync(List<T> obj);
        Task Update(T obj);
        Task Delete(object id);
    }
}