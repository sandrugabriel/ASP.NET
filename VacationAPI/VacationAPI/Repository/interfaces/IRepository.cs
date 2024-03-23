using VacationAPI.Models;

namespace VacationAPI.Repository.interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Vacation>> GetAllAsync();
    }
}
