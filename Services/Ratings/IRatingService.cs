using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRaterMVC.Models.Rating;

namespace RestaurantRaterMVC.Services.Ratings
{
    public class IRatingService
    {
        Task<List<RatingListItem>> GetRatingsAsync();
        Task<List<RatingListItem>> GetRestaurantRatingsAsync(int restaurantId); 
    }
}