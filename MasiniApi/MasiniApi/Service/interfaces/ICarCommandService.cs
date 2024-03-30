using MasiniApi.Dto;
using MasiniApi.Models;

namespace MasiniApi.Service.interfaces
{
    public interface ICarCommandService
    {
        Task<Masini> CreateCar(CreateCarRequest request);

        Task<Masini> UpdateCar(int id,UpdateCarRequest request);

        Task<Masini> DeleteCar(int id);

    }
}
