using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Repository.interfaces;
using System;

namespace StudentApi.Repository
{

    public class RepositoryStudent : IRepositoryStudent
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public RepositoryStudent(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Student.ToListAsync();
        }
    }
}
