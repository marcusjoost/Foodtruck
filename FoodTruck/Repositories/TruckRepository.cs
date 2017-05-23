using FoodTruck.Models;
using FoodTruck.Repositories.Interfaces;
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

        public async Task<bool> DeleteAsync(int foodtruckId)
        {
            var foodtruck = _db.Trucks.FirstOrDefault(i => i.Id == foodtruckId);
            if(foodtruck == null)
            {
                return false;
            }
            _db.Trucks.Remove(foodtruck);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Truck> FindAsync(int foodtruckId)
        {
            return _db.Trucks.Where(i => i.Id == foodtruckId).Select(i => i).FirstOrDefault();
        }
       
        public async Task<bool> UpdateAsync(Models.Truck foodtruck)
        {
            var obj = _db.Trucks.FirstOrDefault(i => i.Id == foodtruck.Id);
            if(foodtruck == null)
            {
                return false;
            }
            obj.Name = foodtruck.Name;
            obj.Coordinates = foodtruck.Coordinates;
            _db.Trucks.Update(foodtruck);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
