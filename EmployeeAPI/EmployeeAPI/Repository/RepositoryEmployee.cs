using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.Models;
using EmployeeAPI.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repository
{
    public class RepositoryEmployee :IRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public RepositoryEmployee(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

    }
}
