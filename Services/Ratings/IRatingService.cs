using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRaterMVC.Models.Rating;

namespace RestaurantRaterMVC.Services.Ratings
{
    public interface IRatingService
    {
        Task<bool> CreateRatingAsync(RatingCreate model);
        Task<List<RatingListItem>> GetRatingsAsync();
        Task<List<RatingListItem>> GetRestaurantRatingsAsync(int restaurantId); 
        Task<bool> DeleteRatingAsync(int id);
    }
}