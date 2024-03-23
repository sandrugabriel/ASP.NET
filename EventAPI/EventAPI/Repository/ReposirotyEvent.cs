using AutoMapper;
using EventAPI.Data;
using EventAPI.Models;
using EventAPI.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventAPI.Repository
{
    public class ReposirotyEvent : IRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ReposirotyEvent(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.Event.ToListAsync();
        }
    }
}
