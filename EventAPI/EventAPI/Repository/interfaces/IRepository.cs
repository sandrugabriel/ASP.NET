using EventAPI.Models;

namespace EventAPI.Repository.interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Event>> GetAllAsync();
    }
}
