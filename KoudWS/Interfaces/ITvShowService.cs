using KoudWS.Models.DTOs;
using KoudWS.Models.ViewModels;

namespace KoudWS.Interfaces
{
    public interface ITvShowService
    {
        Task<TvShowDTO?> AddShow(TvShowVM tvShowVM);
        Task<IEnumerable<TvShowDTO>> GetAll();
        Task<TvShowDTO?> GetShow(string name);
        Task<TvShowDTO?> IsFavorite(TvShowVM tvShowVM);
        Task<bool> DeleteShow(string name);
    }
}