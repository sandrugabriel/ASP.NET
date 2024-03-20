using FluentMigrator;
using Microsoft.EntityFrameworkCore;
using ProduseApi.Models;

namespace ProduseApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Produs> Produs { get; set; }
    }
}
