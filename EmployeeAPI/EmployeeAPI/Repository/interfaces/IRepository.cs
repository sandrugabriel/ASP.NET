using EmployeeAPI.Models;
using System;

namespace EmployeeAPI.Repository.interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
    }
}
