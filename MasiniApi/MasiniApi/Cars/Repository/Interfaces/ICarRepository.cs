using MasiniApi.Cars.Dto;
using MasiniApi.Cars.Models;
using System.Net.Mail;

namespace MasiniApi.Cars.Repository.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();

        Task<Car> GetByNameAsync(string name, string model);

        Task<List<int>> GetAllYear();

        Task<Car> GetByIdAsync(int id);

        Task<Car> CreateCar(CreateCarRequest request);

        Task<Car> UpdateCar(int id, UpdateCarRequest request);

        Task<Car> DeleteCarById(int id);

    }
}
