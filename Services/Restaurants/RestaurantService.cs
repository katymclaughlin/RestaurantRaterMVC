using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Services.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private RestaurantDbContext _context;
        public RestaurantService(RestaurantDbContext context)
        {
            _context = context;
        }
        
        public async Task<bool> CreateRestaurantAsync(RestaurantCreate model)
        {
            Restaurant entity = new()
            {
                Name = model.Name,
                Location = model.Location
            };
            _context.Restaurants.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<IEnumerable<RestaurantListItem>> GetAllRestaurants()
        {
            List<RestaurantListItem> restaurants = await _context.Restaurants
                .Include(r => r.Ratings)
                .Select(r => new RestaurantListItem()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Score = r.AverageRating
                })
                .ToListAsync();
    
            return restaurants;
        }
    }
}




/*
Let's break it down by line of code:

17. We're declaring a variable called restaurants and assigning it the value of the statement to the right of the assignment operator.
18. We're including the the Ratings property in our Restaurant Entity using the Include() method (via the Foreign Key relationship we set up). 
This method will require a using statement for Microsoft.EntityFrameworkCore.
19 We're using the Select method in order to transform our Restaurant entity instances into a new RestaurantListItem instance.
20. The opening curly brace for our object initialization syntax.
21. Assigning the entity (called r) Id value to the new RestaurantListItem Id property.
22. Doing the same as the above, but this time with the Name properties.
23. This time we're assigning the entity AverageRating value to our RestaurantListItem Score property.
24. Closing up our object initialization syntax and our Select method
25. Taking our new queried selection and converting it into a C# List.
*/