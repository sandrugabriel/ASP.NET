using MasiniApi.Dto;
using MasiniApi.Exceptions;
using MasiniApi.Models;
using MasiniApi.Repository.Interfaces;
using MasiniApi.Service.interfaces;

namespace MasiniApi.Service
{
    public class CarCommandService : ICarCommandService
    {
        private ICarRepository _carRepository;

        public CarCommandService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Masini> CreateCar(CreateCarRequest request)
        {
            if (request.Marca == "")
            {
                throw new InvalidMarca(Constants.Constants.INVALID_MARCA);
            }

            if (request.Model == "")
            {
                throw new InvalidModel(Constants.Constants.INVALID_MODEL);
            }

            var car = await _carRepository.CreateCar(request);

            return car;
        }

        public async Task<Masini> DeleteCar(int id)
        {
           var car = await _carRepository.GetByIdAsync(id);

            if(car == null)
            {
                throw new ItemDoesNotExist(Constants.Constants.CAR_DOES_NOT_EXIST);
            }

            await _carRepository.DeleteCarById(id);
            return car;

        }

        public async Task<Masini> UpdateCar(int id,UpdateCarRequest request)
        {
            if (request.Marca == "")
            {
                throw new InvalidMarca(Constants.Constants.INVALID_MARCA);
            }

            if (request.Model == "")
            {
                throw new InvalidModel(Constants.Constants.INVALID_MODEL);
            }

            var car = await _carRepository.GetByIdAsync(id);
            if(car == null)
            {
                throw new ItemDoesNotExist(Constants.Constants.CAR_DOES_NOT_EXIST);
            }

            car = await _carRepository.UpdateCar(id, request);
            return car;

        }
    }
}
