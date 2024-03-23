using AutoMapper;
using BookAPI.Data;
using BookAPI.Models;
using BookAPI.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookAPI.Repository
{
    public class RepositoryBook:IRepositoryBook
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public RepositoryBook(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Book.ToListAsync();
        }
    }
}
