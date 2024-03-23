using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VacationAPI.Models;

namespace VacationAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Vacation> Vacations { get; set; }
    }
}
