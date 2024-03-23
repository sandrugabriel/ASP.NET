using ApartamentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Apartament> Apartaments { get; set; }
    }
}
