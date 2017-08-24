using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTruck.Models;
using FoodTruck.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var query = await _db.Menues.FirstOrDefaultAsync(i => i.Id == value.Id);
            if (query != null)
            {
                throw new InvalidOperationException("Item already exists in the database.");
            }

            _db.Menues.Add(value);
            await _db.SaveChangesAsync();
            return value.Id;
        }

        public async Task<bool> DeleteAsync(int menuId)
        {
            var menu = await _db.Menues.FirstOrDefaultAsync(i => i.Id == menuId);
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
            return await _db.Menues.FirstOrDefaultAsync(i => i.Id == menuId);
        }

        public async Task<bool> UpdateAsync(Menu menu)
        {
            if (menu == null)
            {
                return false;
            }
            _db.Menues.Update(menu);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
