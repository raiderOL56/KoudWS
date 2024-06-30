using System.Linq.Expressions;
using KoudWS.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace KoudWS.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ContextDB _context;
        public GenericRepository(ContextDB context)
        {
            _context = context;
        }
        public void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                T? entity = await GetByIdAsync(id);

                if (entity != null)
                    Delete(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T>? Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                return _context.Set<T>().Where(expression);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task InsertAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}