using System;
using System.Linq;
using System.Threading.Tasks;
using FoodTruck.Models;
using FoodTruck.Repositories.Interfaces;

namespace FoodTruck.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly Context _db;
        public DishRepository(Context db)
        {
            _db = db;
        }
        public async Task<int> CreateAsync(Dish value)
        {
            var query = _db.Dishes.Where(i => i.Id == value.Id).Select(i => i);
            if (value.Id != 0 && query.FirstOrDefault() != null) throw new InvalidOperationException("Item already exists in the database.");

            _db.Dishes.Add(value);
            await _db.SaveChangesAsync();
            return value.Id;
        }

        public async Task<bool> DeleteAsync(int dishId)
        {
            var dish = _db.Dishes.FirstOrDefault(i => i.Id == dishId);
            if (dish == null)
            {
                return false;
            }
            _db.Dishes.Remove(dish);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Dish> FindAsync(int dishId)
        {
            return _db.Dishes.FirstOrDefault(i => i.Id == dishId);
        }

        public async Task<bool> UpdateAsync(Dish dish, int id)
        {
            if (dish == null)
            {
                return false;
            }
            var obj = _db.Dishes.FirstOrDefault(i => i.Id == id);
            if(dish == null)
            {
                return false;
            }
            obj.Name = dish.Name;
            obj.Price = dish.Price;
            _db.Dishes.Update(obj);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
