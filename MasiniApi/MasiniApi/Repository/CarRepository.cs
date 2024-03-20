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
    }
}
