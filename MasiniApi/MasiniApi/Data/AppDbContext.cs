using MasiniApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MasiniApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Masini> Masini { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Masini>()
                .HasOne(a => a.User)
                .WithMany(a => a.Masini)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);          
        }
    }
}
