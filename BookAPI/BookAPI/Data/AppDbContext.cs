using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
    }
}
