using FoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        Task<int> CreateMenuAsync(Menu menu);
        Task<bool> UpdateMenuAsync(Menu menu);
        Task<bool> DeleteMenuAsync(int menuId);
        Menu GetMenu(int menuId);
    }
}
