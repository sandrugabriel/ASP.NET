using MasiniApi.Models;

namespace MasiniApi.Repository.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Masini>> GetAllAsync();
    }
}
