using FoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Repositories.Interfaces
{
    public interface ITruckRepository
    {
        Task<int> CreateAsync(Truck foodtruck);
        Task<bool> UpdateAsync(Truck foodtruck, int id);
        Task<bool> DeleteAsync(int foodtruckId);
        Task<Truck> FindAsync(int foodtruckId);
    }
}
