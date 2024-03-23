using BankAccountAPI.Models;
using System;

namespace BankAccountAPI.Repository.interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<BankAccount>> GetAllAsync();
    }
}
