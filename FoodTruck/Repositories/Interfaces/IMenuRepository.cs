using FoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        Task<int> CreateAsync(Menu menu);
        Task<bool> UpdateAsync(Menu menu, int id);
        Task<bool> DeleteAsync(int menuId);
        Task<Menu> FindAsync(int menuId);
    }
}
