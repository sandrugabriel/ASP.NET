using BankAccountAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BankAccountAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<BankAccount> BankAccounts { get; set; }
    }
}
