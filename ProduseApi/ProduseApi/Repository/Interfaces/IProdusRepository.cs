using ProduseApi.Models;

namespace ProduseApi.Repository.Interfaces
{
    public interface IProdusRepository
    {
        Task<IEnumerable<Produs>> GetAllAsync();
    }
}
