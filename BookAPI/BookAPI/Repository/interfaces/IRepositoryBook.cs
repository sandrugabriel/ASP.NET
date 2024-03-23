using BookAPI.Models;

namespace BookAPI.Repository.interfaces
{
    public interface IRepositoryBook
    {
        Task<IEnumerable<Book>> GetAllAsync();
    }
}
