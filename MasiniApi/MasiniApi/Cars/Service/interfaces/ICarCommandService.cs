using MasiniApi.Cars.Dto;
using MasiniApi.Cars.Models;

namespace MasiniApi.Cars.Service.interfaces
{
    public interface ICarCommandService
    {
        Task<Car> CreateCar(CreateCarRequest request);

        Task<Car> UpdateCar(int id, UpdateCarRequest request);

        Task<Car> DeleteCar(int id);

    }
}
