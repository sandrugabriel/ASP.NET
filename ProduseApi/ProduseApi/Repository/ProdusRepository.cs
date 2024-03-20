using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProduseApi.Data;
using ProduseApi.Models;
using ProduseApi.Repository.Interfaces;


namespace ProduseApi.Repository
{
    public class ProdusRepository : IProdusRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ProdusRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Produs>> GetAllAsync()
        {
            return await _context.Produs.ToListAsync();
        }
    }
}
