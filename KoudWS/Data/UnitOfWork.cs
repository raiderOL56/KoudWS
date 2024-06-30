using KoudWS.Interfaces;
using KoudWS.Interfaces.Repository;

namespace KoudWS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextDB _context;
        public ITvShowRepository TvShowRepository { get; private set; }
        public UnitOfWork(ContextDB context, ITvShowRepository tvShowRepository)
        {
            _context = context;
            TvShowRepository = tvShowRepository;
        }

        public async Task<int> CommitAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                _context.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}