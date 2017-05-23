using FoodTruck.Models;
using FoodTruck.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly Context _db;
        public TruckRepository(Context db) 
        {
            _db = db;
        }

        public async Task<int> CreateAsync(Truck value)
        {
            var query = _db.Trucks.Where(i => i.Id == value.Id).Select(i => i);
            if (value.Id != 0 && query.FirstOrDefault() != null) throw new InvalidOperationException("Item already exists in the database.");

            _db.Trucks.Add(value);
            await _db.SaveChangesAsync();
            return value.Id;
        }

        public async Task<bool> DeleteAsync(int truckId)
        {
            var foodtruck = _db.Trucks.FirstOrDefault(i => i.Id == truckId);
            if(foodtruck == null)
            {
                return false;
            }
            _db.Trucks.Remove(foodtruck);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Truck> FindAsync(int truckId)
        {
            return _db.Trucks.FirstOrDefault(i => i.Id == truckId);
        }
       
        public async Task<bool> UpdateAsync(Truck truck, int id)
        {
            if (truck == null)
            {
                return false;
            }
            var obj = _db.Trucks.FirstOrDefault(i => i.Id == id);
            if (truck == null)
            {
                return false;
            }

            obj.Name = truck.Name;
            obj.Coordinates = truck.Coordinates;

            _db.Update(obj);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
