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
        
        public async Task<int> CreateAsync(Rating value)
        {
            var query = _db.Ratings.Where(i => i.Id == value.Id).Select(i => i);
            if (value.Id != 0 && query.FirstOrDefault() != null) throw new InvalidOperationException("Item already exists in the database.");

            _db.Ratings.Add(value);
            await _db.SaveChangesAsync();
            return value.Id;
        }

        public async Task<bool> UpdateAsync(Rating rating, int id)
        {
            if (rating == null)
            {
                return false;
            }
            var obj = _db.Ratings.FirstOrDefault(i => i.Id == id);
            if(obj == null)
            {
                return false;
            }
            obj.Review = rating.Review;
            obj.Stars = rating.Stars;

            _db.Ratings.Update(obj);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int ratingId)
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

        public async Task<Rating> FindAsync(int ratingId)
        {
            return _db.Ratings.FirstOrDefault(i => i.Id == ratingId);
        }

    }
}
