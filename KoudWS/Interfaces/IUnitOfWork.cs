using KoudWS.Interfaces.Repository;

namespace KoudWS.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITvShowRepository TvShowRepository { get; }
        Task<int> CommitAsync();
    }
}