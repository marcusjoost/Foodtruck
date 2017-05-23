using FoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Task<int> CreateRatingAsync(Rating rating);
        Task<bool> UpdateRatingAsync(Rating rating);
        Task<bool> DeleteRatingAsync(int ratingId);
        IEnumerable<Rating> GetRatingToFoodtruck(int foodtruckId);
        IEnumerable<Rating> GetRatingToUser(int userId);
        Rating GetRating(int ratingId);
    }
}
