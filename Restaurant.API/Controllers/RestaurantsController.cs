using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using System.Threading.Tasks;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await restaurantsService.GetRestaurants();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById([FromRoute] int id)
        {
           var restaurant = await restaurantsService.GetRestaurantById(id);
           if(restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
           int id = await restaurantsService.CreateRestaurant(createRestaurantDto);
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
        }

    }
}
