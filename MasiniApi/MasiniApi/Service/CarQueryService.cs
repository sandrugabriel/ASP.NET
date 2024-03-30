using MasiniApi.Constants;
using MasiniApi.Exceptions;
using MasiniApi.Models;
using MasiniApi.Repository.Interfaces;
using MasiniApi.Service.interfaces;

namespace MasiniApi.Service
{
    public class CarQueryService : ICarQueryService
    {
        private ICarRepository _carRepository;

        public CarQueryService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        public async Task<IEnumerable<Masini>> GetAllAsync()
        {
            IEnumerable<Masini> cars = await _carRepository.GetAllAsync();

            if(cars.Count() <= 0)
            {
                throw new ItemsDoNotExists(Constants.Constants.NO_CAR_EXIST);
            }

            return cars;
        }

        public async Task<List<int>> GetAllYear()
        {
            List<int> year = await _carRepository.GetAllYear();

            if(year.Count() <= 0)
            {
                throw new ItemsDoNotExists(Constants.Constants.NO_CAR_EXIST);
            }

            return year;
        }

        public async Task<Masini> GetByIdAsync(int id)
        {
            Masini car = await _carRepository.GetByIdAsync(id);

            if(car == null)
            {
                throw new ItemDoesNotExist(Constants.Constants.CAR_DOES_NOT_EXIST);
            }

            return (Masini)car;
        }

        public async Task<Masini> GetByNameAsync(string name, string model)
        {
            Masini car = await _carRepository.GetByNameAsync(name, model);

            if(car == null)
            {
                throw new ItemDoesNotExist(Constants.Constants.CAR_DOES_NOT_EXIST);
            }

            return (Masini)car;
        }
    }
}
