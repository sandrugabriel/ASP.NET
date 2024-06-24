using MasiniApi.Cars.Models;

namespace MasiniApi.Cars.Service.interfaces
{
    public interface ICarQueryService
    {

        Task<IEnumerable<Car>> GetAllAsync();

        Task<Car> GetByNameAsync(string name, string model);

        Task<List<int>> GetAllYear();

        Task<Car> GetByIdAsync(int id);

    }
}
