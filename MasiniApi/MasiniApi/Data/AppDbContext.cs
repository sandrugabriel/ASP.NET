using MasiniApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MasiniApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Masini> Masini { get; set; }
    }
}
