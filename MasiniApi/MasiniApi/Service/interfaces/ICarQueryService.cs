using MasiniApi.Models;

namespace MasiniApi.Service.interfaces
{
    public interface ICarQueryService
    {

        Task<IEnumerable<Masini>> GetAllAsync();

        Task<Masini> GetByNameAsync(string name, string model);

        Task<List<int>> GetAllYear();

        Task<Masini> GetByIdAsync(int id);

    }
}
