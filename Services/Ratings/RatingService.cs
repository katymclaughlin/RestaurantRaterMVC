using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRaterMVC.Data;
using RestaurantRaterMVC.Models.Rating;
using Microsoft.EntityFrameworkCore;

namespace RestaurantRaterMVC.Services.Ratings;

    public class RatingService : IRatingService
    {
        private readonly RestaurantDbContext _context;
        public RatingService(RestaurantDbContext context)
        {
        _context = context;
        }

        public async Task<bool> CreateRatingAsync(RatingCreate model)
        {
            Rating entity = new()
            {
                RestaurantId = model.RestaurantId,
                Score = model.Score
            };

            _context.Ratings.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<List<RatingListItem>> GetRatingsAsync()
        {
            var ratings = await _context.Ratings
                .Include(r => r.Restaurant)
                .Select(r => new RatingListItem
                {
                    RestaurantName = r.Restaurant.Name,
                    Score = r.Score
                })
                .ToListAsync();

            return ratings;
        }

        public async Task<List<RatingListItem>> GetRestaurantRatingsAsync(int restaurantId)
        {
            var ratings = await _context.Ratings
                .Include(r => r.Restaurant)
                .Where(r => r.RestaurantId == restaurantId)
                .Select(r => new RatingListItem
                {
                    RestaurantName = r.Restaurant.Name,
                    Score = r.Score
                })
                .ToListAsync();

            return ratings;
        }

        public async Task<bool> DeleteRatingAsync (int id)
        {
            var ratings = await _context.Ratings.FindAsync(id);
            if (ratings is null)
                return false;

            _context.Ratings.Remove(ratings);
            return await _context.SaveChangesAsync() == 1;    
        }
    }
