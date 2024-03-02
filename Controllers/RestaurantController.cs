using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Services.Restaurants;
using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Controllers;

    public class RestaurantController : Controller
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

//NOTE - Add Endpoint to return Detail view for a restaurant
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            RestaurantDetail? model = await _service.GetRestaurantAsync(id);

            if (model is null)
                return NotFound();
    
        return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RestaurantCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.CreateRestaurantAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }

