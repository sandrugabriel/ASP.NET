using AutoMapper;
using MasiniApi.Cars.Dto;
using MasiniApi.Cars.Models;
using MasiniApi.Cars.Repository.Interfaces;
using MasiniApi.Data;
using Microsoft.EntityFrameworkCore;

namespace MasiniApi.Cars.Repository
{
    public class CarRepository : ICarRepository
    {
        private AppDbContext _context;
        IMapper _mapper;

        public CarRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Masini.ToListAsync();
        }

        public async Task<List<int>> GetAllYear()
        {
            List<Car> allcars = await _context.Masini.ToListAsync();

            List<int> allyears = new List<int>();

            for (int i = 0; i < allcars.Count; i++)
                allyears.Add(allcars[i].Year);
            return allyears;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            List<Car> cars = await _context.Masini.ToListAsync();

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Id == id) return cars[i];
            }

            return null;
        }

        public async Task<Car> GetByNameAsync(string marca, string model)
        {
            List<Car> allcars = await _context.Masini.ToListAsync();

            for (int i = 0; i < allcars.Count; i++)
            {
                if (allcars[i].Brand.Equals(marca) && allcars[i].Model.Equals(model))
                {
                    return allcars[i];
                }
            }

            return null;
        }

        public async Task<Car> CreateCar(CreateCarRequest request)
        {

            var car = _mapper.Map<Car>(request);

            _context.Masini.Add(car);

            await _context.SaveChangesAsync();

            return car;

        }

        public async Task<Car> UpdateCar(int id, UpdateCarRequest request)
        {

            var car = await _context.Masini.FindAsync(id);

            car.Brand = request.Brand ?? car.Brand;
            car.Model = request.Model ?? car.Model;
            car.Year = request.Year ?? car.Year;
            car.Color = request.Color ?? car.Color;

            _context.Masini.Update(car);

            await _context.SaveChangesAsync();

            return car;

        }

        public async Task<Car> DeleteCarById(int id)
        {
            var car = await _context.Masini.FindAsync(id);

            _context.Masini.Remove(car);

            await _context.SaveChangesAsync();

            return car;
        }

    }
}
