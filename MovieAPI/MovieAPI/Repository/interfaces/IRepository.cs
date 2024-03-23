using MovieAPI.Models;

namespace MovieAPI.Repository.interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
    }
}
