using ApartamentAPI.Data;
using ApartamentAPI.Models;
using ApartamentAPI.Repository.interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApartamentAPI.Repository
{
    public class RepositoryApartament : IRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public RepositoryApartament(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Apartament>> GetAllAsync()
        {
            return await _context.Apartaments.ToListAsync();
        }
    }
}
