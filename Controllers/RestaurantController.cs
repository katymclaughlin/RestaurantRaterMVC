using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Services.Restaurants;

namespace RestaurantRaterMVC.Controllers
{
    public class RestaurantController : Controller;
    {
        private IRestaurantService _service;
        public RestaurantController(IRestaurantService service)
        {
        _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
        List<RestaurantListItem> restaurants = await _service.GetAllRestaurantsAsync();
        return View(restaurants);
        }
    }
}