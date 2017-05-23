using FoodTruck.Models;
using FoodTruck.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly Context _db;
        public RatingRepository(Context db)
        {
            _db = db;
        }
        
        public async Task<int> CreateRatingAsync(Rating rating)
        {
            var obj = new Rating { FoodTruckId = rating.FoodTruckId, Review = rating.Review, Stars = rating.Stars, UserId = rating.UserId };
            _db.Ratings.Add(obj);
            await _db.SaveChangesAsync();
            return obj.Id = rating.Id;
        }

        public async Task<bool> UpdateRatingAsync(Rating rating)
        {
            var obj = _db.Ratings.FirstOrDefault(i => i.UserId == rating.UserId && i.FoodTruckId == rating.FoodTruckId);
            if(obj == null)
            {
                return false;
            }
            obj.Review = rating.Review;
            obj.Stars = rating.Stars;
            _db.Ratings.Update(rating);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRatingAsync(int ratingId)
        {
            var rating = _db.Ratings.FirstOrDefault(i => i.Id == ratingId);
            if (rating == null)
            {
                return false;
            }
            _db.Ratings.Remove(rating);
            await _db.SaveChangesAsync();
            return true;
        }
        public IEnumerable<Rating> GetRatingToFoodtruck(int foodtruckId)
        {
            return _db.Ratings.Where(i => i.FoodTruckId == foodtruckId);
        }

        public IEnumerable<Rating> GetRatingToUser(int userId)
        {
            return _db.Ratings.Where(i => i.UserId == userId);
        }

        public Rating GetRating(int ratingId)
        {
            return _db.Ratings.FirstOrDefault(i => i.Id == ratingId);
        }

    }
}
