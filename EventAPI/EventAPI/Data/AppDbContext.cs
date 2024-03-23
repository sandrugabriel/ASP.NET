using EventAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Event> Event { get; set; }
    }
}
