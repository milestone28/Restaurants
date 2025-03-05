
using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
    {
         
        //public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
        //{
        //    logger.LogInformation("Getting all restaurants");
        //    var restaurants = await restaurantsRepository.GetAllAsync();
        //    var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        //    return restaurantsDtos!;
        //}

        //public async Task<RestaurantDto?> GetRestaurantById(int id)
        //{
        //    logger.LogInformation($"Getting restaurant {id}");
        //    var restaurant = await restaurantsRepository.GetByIdAsync(id);
        //    var restaurantsDtos = mapper.Map<RestaurantDto?>(restaurant);
        //    return restaurantsDtos;
        //}

        //public async Task<int> CreateRestaurant(CreateRestaurantDto createRestaurantDto)
        //{
        //    logger.LogInformation("Creating a new restaurant");
        //    var restaurant = mapper.Map<Restaurant>(createRestaurantDto);
        //    var id = await restaurantsRepository.CreateAsync(restaurant);
        //    return id;
        //}
    }
}
