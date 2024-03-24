using MasiniApi.Models;

namespace MasiniApi.Repository.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Masini>> GetAllAsync();

        Task<Masini> GetByNameAsync(string name,string model);

        Task<List<int>> GetAllYear();

        Task<Masini> GetByIdAsync(int id);


    }
}
