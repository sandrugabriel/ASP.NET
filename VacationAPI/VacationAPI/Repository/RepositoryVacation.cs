using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VacationAPI.Data;
using VacationAPI.Models;
using VacationAPI.Repository.interfaces;

namespace VacationAPI.Repository
{
    public class RepositoryVacation : IRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public RepositoryVacation(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Vacation>> GetAllAsync()
        {
            return await _context.Vacations.ToListAsync();
        }
    }
}
