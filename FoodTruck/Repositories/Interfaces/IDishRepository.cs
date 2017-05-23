using FoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Repositories.Interfaces
{
    public interface IDishRepository
    {
        Task<int> CreateDishAsync(Dish dish);
        Task<bool> UpdateDishAsync(Dish dish);
        Task<bool> DeleteDishAsync(int dishId);
        Dish GetDish(int dishId);
    }
}
