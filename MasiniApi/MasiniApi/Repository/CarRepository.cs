using AutoMapper;
using MasiniApi.Data;
using MasiniApi.Dto;
using MasiniApi.Models;
using MasiniApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MasiniApi.Repository
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

        public async Task<IEnumerable<Masini>> GetAllAsync()
        {
            return await _context.Masini.ToListAsync();
        }

        public async Task<List<int>> GetAllYear()
        {
            List<Masini> allcars = await _context.Masini.ToListAsync();

            List<int> allyears = new List<int>();

            for(int i = 0; i < allcars.Count; i++)
                allyears.Add(allcars[i].Year);
            return allyears;
        }

        public async Task<Masini> GetByIdAsync(int id)
        {
            List<Masini> cars = await _context.Masini.ToListAsync();

            for(int i=0;i< cars.Count; i++)
            {
                if(cars[i].Id == id) return cars[i];
            }

            return null;
        }

        public async Task<Masini> GetByNameAsync(string marca, string model)
        {
            List<Masini> allcars = await _context.Masini.ToListAsync();

            for(int i=0;i<allcars.Count;i++)
            {
                if (allcars[i].Marca.Equals(marca) && allcars[i].Model.Equals(model))
                {
                    return allcars[i];
                }
            }

            return null;
        }

        public async Task<Masini> CreateCar(CreateCarRequest request)
        {

            var car = _mapper.Map<Masini>(request);

            _context.Masini.Add(car);

            await _context.SaveChangesAsync();

            return car;

        }

        public async Task<Masini> UpdateCar(int id,UpdateCarRequest request)
        {

            var car = await _context.Masini.FindAsync(id);

            car.Marca = request.Marca ?? car.Marca;
            car.Model = request.Model ?? car.Model;
            car.Year = request.Anul ?? car.Year;
            car.Culoare = request.Culoarea ?? car.Culoare;

            _context.Masini.Update(car);

            await _context.SaveChangesAsync();

            return car;
          
        }

        public async Task<Masini> DeleteCarById(int id)
        {
            var car = await _context.Masini.FindAsync(id);

            _context.Masini.Remove(car);

            await _context.SaveChangesAsync();

            return car;
        }

    }
}
