using ApartamentAPI.Models;
using System;

namespace ApartamentAPI.Repository.interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Apartament>> GetAllAsync();
    }
}
