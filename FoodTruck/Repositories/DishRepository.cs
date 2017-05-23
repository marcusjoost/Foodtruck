using System;
using System.Collections.Generic;
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
        public async Task<int> CreateDishAsync(Dish dish)
        {
            var obj = new Dish { Name = dish.Name, Price = dish.Price };
            _db.Dishes.Add(obj);
            await _db.SaveChangesAsync();
            return obj.Id = dish.Id;
        }

        public async Task<bool> DeleteDishAsync(int dishId)
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

        public Dish GetDish(int dishId)
        {
            return _db.Dishes.FirstOrDefault(i => i.Id == dishId);
        }

        public async Task<bool> UpdateDishAsync(Dish dish)
        {
            var obj = _db.Dishes.FirstOrDefault(i => i.Id == dish.Id);
            if(dish == null)
            {
                return false;
            }
            obj.Name = dish.Name;
            obj.Price = dish.Price;
            _db.Dishes.Update(obj);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
