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

        public async Task<int> CreateAsync(Menu value)
        {
            var query = _db.Menues.Where(i => i.Id == value.Id).Select(i => i);
            if (value.Id != 0 && query.FirstOrDefault() != null) throw new InvalidOperationException("Item already exists in the database.");

            _db.Menues.Add(value);
            await _db.SaveChangesAsync();
            return value.Id;
        }

        public async Task<bool> DeleteAsync(int menuId)
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

        public async Task<Menu> FindAsync(int menuId)
        {
            return _db.Menues.FirstOrDefault(i => i.Id == menuId);
        }

        public async Task<bool> UpdateAsync(Menu menu, int id)
        {
            if (menu == null)
            {
                return false;
            }
            var obj = _db.Menues.FirstOrDefault(i => i.Id == id);
            if(obj == null)
            {
                return false;
            }
            obj.FoodTruckId = menu.FoodTruckId;
            obj.Dishes = menu.Dishes;
            _db.Menues.Update(obj);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
