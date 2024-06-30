using System.Linq.Expressions;

namespace KoudWS.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        IEnumerable<T>? Find(Expression<Func<T, bool>> expression);
        Task InsertAsync(T entity);
        Task InsertRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        Task DeleteAsync(int id);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}