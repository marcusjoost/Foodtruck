using FoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Task<int> CreateAsync(Rating rating);
        Task<bool> UpdateAsync(Rating rating);
        Task<bool> DeleteAsync(int ratingId);
        IEnumerable<Rating> GetRatingToFoodtruck(int foodtruckId);
        IEnumerable<Rating> GetRatingToUser(int userId);
        Task<Rating> FindAsync(int ratingId);
    }
}
