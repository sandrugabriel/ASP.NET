using MasiniApi.Cars.Models;
using MasiniApi.Cars.Repository.Interfaces;
using MasiniApi.Cars.Service.interfaces;
using MasiniApi.System.Constants;
using MasiniApi.System.Exceptions;

namespace MasiniApi.Cars.Service
{
    public class CarQueryService : ICarQueryService
    {
        private ICarRepository _carRepository;

        public CarQueryService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            IEnumerable<Car> cars = await _carRepository.GetAllAsync();

            if (cars.Count() <= 0)
            {
                throw new ItemsDoNotExists(Constants.NO_CAR_EXIST);
            }

            return cars;
        }

        public async Task<List<int>> GetAllYear()
        {
            List<int> year = await _carRepository.GetAllYear();

            if (year.Count() <= 0)
            {
                throw new ItemsDoNotExists(Constants.NO_CAR_EXIST);
            }

            return year;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            Car car = await _carRepository.GetByIdAsync(id);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            return car;
        }

        public async Task<Car> GetByNameAsync(string name, string model)
        {
            Car car = await _carRepository.GetByNameAsync(name, model);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            return car;
        }
    }
}
