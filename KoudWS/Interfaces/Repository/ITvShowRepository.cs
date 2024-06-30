using KoudWS.Models.Entities;

namespace KoudWS.Interfaces.Repository
{
    public interface ITvShowRepository : IGenericRepository<TvShowEntity>
    {
        Task<TvShowEntity?> GetByName(string name);
    }
}