using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;

namespace StudentApi.Repository.interfaces
{
    public interface IRepositoryStudent
    {
        Task<IEnumerable<Student>> GetAllAsync();
    }
}
