using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRaterMVC.Data;

namespace RestaurantRaterMVC.Services.Ratings;

    public class RatingService : IRatingService
    {
        private readonly RestaurantDbContext _context;
        public RatingService(RestaurantDbContext context)
        {
        _context = context;
        }
    }
