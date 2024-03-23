using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;
using MovieAPI.Repository.interfaces;

namespace MovieAPI.Repository
{
    public class RepositoryMovie : IRepository
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public RepositoryMovie(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movie.ToListAsync();
        }
    }
}
