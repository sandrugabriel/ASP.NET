using AutoMapper;
using MasiniApi.Data;
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
                allyears.Add(allcars[i].Data.Year);
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
    }
}
