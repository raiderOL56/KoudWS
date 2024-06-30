using KoudWS.Interfaces.Repository;
using KoudWS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoudWS.Data.Repository
{
    public class TvShowRepository : GenericRepository<TvShowEntity>, ITvShowRepository
    {
        public TvShowRepository(ContextDB context) : base(context)
        {
        }

        public async Task<TvShowEntity?> GetByName(string name)
        {
            try
            {
                return await _context.TvShow.FirstOrDefaultAsync(entity => entity.Name_tvshow == name);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}