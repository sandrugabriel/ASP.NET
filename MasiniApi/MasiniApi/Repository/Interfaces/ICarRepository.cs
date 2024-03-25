using MasiniApi.Dto;
using MasiniApi.Models;
using System.Net.Mail;

namespace MasiniApi.Repository.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Masini>> GetAllAsync();

        Task<Masini> GetByNameAsync(string name,string model);

        Task<List<int>> GetAllYear();

        Task<Masini> GetByIdAsync(int id);

        Task<Masini> CreateCar(CreateCarRequest request);

        Task<Masini> UpdateCar(int id,UpdateCarRequest request);

        Task<Masini> DeleteCarById(int id);   

    }
}
