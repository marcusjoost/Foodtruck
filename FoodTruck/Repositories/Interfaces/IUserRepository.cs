using FoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        User GetUser(int userId);
    }
}
