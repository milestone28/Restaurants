﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurant;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            // var restaurants = await restaurantsService.GetRestaurants();
            var restaurants = await mediator.Send(new GetAllRestaurantQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById([FromRoute] int id)
        {
           //var restaurant = await restaurantsService.GetRestaurantById(id);
           var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantById([FromRoute] int id)
        {
            //var restaurant = await restaurantsService.GetRestaurantById(id);
            var isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRestaurantById([FromRoute] int id, UpdateRestaurantCommand command)
        {
            command.Id = id;
            var isUpdated = await mediator.Send(command);

            if (isUpdated)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        //public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            //int id = await restaurantsService.CreateRestaurant(createRestaurantDto);
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
        }

    }
}
