using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTruck.Models;
using FoodTruck.Repositories.Interfaces;

namespace FoodTruck.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly Context _db;
        public MenuRepository(Context db)
        {
            _db = db;
        }

        public async Task<int> CreateMenuAsync(Menu menu)
        {
            var obj = new Menu { Dishes = menu.Dishes, FoodTruckId = menu.FoodTruckId};
            _db.Menues.Add(obj);
            await _db.SaveChangesAsync();
            return obj.Id = menu.Id;
        }

        public async Task<bool> DeleteMenuAsync(int menuId)
        {
            var menu = _db.Menues.FirstOrDefault(i => i.Id == menuId);
            if(menu == null)
            {
                return false;
            }
            _db.Menues.Remove(menu);
            await _db.SaveChangesAsync();
            return true;
        }

        public Menu GetMenu(int menuId)
        {
            return _db.Menues.FirstOrDefault(i => i.Id == menuId);
        }

        public async Task<bool> UpdateMenuAsync(Menu menu)
        {
            var obj = _db.Menues.FirstOrDefault(i => i.Id == menu.Id);
            if(obj == null)
            {
                return false;
            }
            obj.FoodTruckId = menu.FoodTruckId;
            obj.Dishes = menu.Dishes;
            _db.Menues.Update(obj);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
