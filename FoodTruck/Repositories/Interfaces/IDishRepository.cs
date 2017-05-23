using FoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Repositories.Interfaces
{
    public interface IDishRepository
    {
        Task<int> CreateAsync(Dish dish);
        Task<bool> UpdateAsync(Dish dish, int id);
        Task<bool> DeleteAsync(int dishId);
        Task<Dish> FindAsync(int dishId);
    }
}
