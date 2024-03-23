using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
