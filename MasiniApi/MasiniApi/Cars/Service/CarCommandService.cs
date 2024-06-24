using MasiniApi.Cars.Dto;
using MasiniApi.Cars.Models;
using MasiniApi.Cars.Repository.Interfaces;
using MasiniApi.Cars.Service.interfaces;
using MasiniApi.System.Constants;
using MasiniApi.System.Exceptions;

namespace MasiniApi.Cars.Service
{
    public class CarCommandService : ICarCommandService
    {
        private ICarRepository _carRepository;

        public CarCommandService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> CreateCar(CreateCarRequest request)
        {
            if (request.Brand == "")
            {
                throw new InvalidMarca(Constants.INVALID_MARCA);
            }

            if (request.Model == "")
            {
                throw new InvalidModel(Constants.INVALID_MODEL);
            }

            var car = await _carRepository.CreateCar(request);

            return car;
        }

        public async Task<Car> DeleteCar(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            await _carRepository.DeleteCarById(id);
            return car;

        }

        public async Task<Car> UpdateCar(int id, UpdateCarRequest request)
        {
            if (request.Brand == "")
            {
                throw new InvalidMarca(Constants.INVALID_MARCA);
            }

            if (request.Model == "")
            {
                throw new InvalidModel(Constants.INVALID_MODEL);
            }

            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            car = await _carRepository.UpdateCar(id, request);
            return car;

        }
    }
}
