using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Services.Ratings;
using RestaurantRaterMVC.Models.Rating;

namespace RestaurantRaterMVC.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingService _service;
        public RatingController(IRatingService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<RatingListItem> model = await _service.GetRatingsAsync();
            return View(model);
        }
    }
}