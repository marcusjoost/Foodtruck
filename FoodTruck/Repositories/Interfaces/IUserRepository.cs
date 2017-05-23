using FoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(User user);
        Task<bool> UpdateAsync(User user, int id);
        Task<bool> DeleteAsync(int userId);
        Task<User> FindAsync(int userId);
    }
}
