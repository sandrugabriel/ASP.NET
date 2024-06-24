using MasiniApi.Cars.Models;
using MasiniApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MasiniApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Car> Masini { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(a => a.User)
                .WithMany(a => a.Masini)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);          
        }
    }
}
