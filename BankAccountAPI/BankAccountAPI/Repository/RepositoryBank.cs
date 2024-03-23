using AutoMapper;
using BankAccountAPI.Data;
using BankAccountAPI.Models;
using BankAccountAPI.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace BankAccountAPI.Repository
{
    public class RepositoryBank : IRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public RepositoryBank(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BankAccount>> GetAllAsync()
        {
            return await _context.BankAccounts.ToListAsync();
        }
    }
}
