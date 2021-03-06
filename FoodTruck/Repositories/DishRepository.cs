﻿using System;
using System.Threading.Tasks;
using FoodTruck.Models;
using FoodTruck.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var query = await _db.Dishes.FirstOrDefaultAsync(i => i.Id == value.Id);
            if (query != null)
            {
                throw new InvalidOperationException("Dish already exist in the database");
            }

            _db.Dishes.Add(value);
            await _db.SaveChangesAsync();
            return value.Id;
        }

        public async Task<bool> DeleteAsync(int dishId)
        {
            var dish = await _db.Dishes.FirstOrDefaultAsync(i => i.Id == dishId);
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
            return await _db.Dishes.FirstOrDefaultAsync(i => i.Id == dishId);
        }

        //
        //public async Task<bool> UpdateAsync(Dish dish, int id)
        //{
        //    if (dish == null)
        //    {
        //        return false;
        //    }
        //    var obj = _db.Dishes.FirstOrDefault(i => i.Id == id);
        //    if(dish == null)
        //    {
        //        return false;
        //    }
        //    obj.Name = dish.Name;
        //    obj.Price = dish.Price;
        //    _db.Dishes.Update(obj);

        //    return await _db.SaveChangesAsync() > 0;
        //}
        public async Task<bool> UpdateAsync(Dish dish)
        {
            if (dish == null)
            {
                return false;
            }
            _db.Dishes.Update(dish);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
