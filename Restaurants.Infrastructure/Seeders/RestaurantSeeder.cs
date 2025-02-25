using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Restaurants.Any())
                {
                    var restaurant = GetRestaurants();
                    dbContext.Restaurants.AddRange(restaurant);
                    await dbContext.SaveChangesAsync();
                }
            }

        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = [
                new Restaurant()
                {
                    Name = "McDonalds",
                    Description = "Fast food restaurant",
                    Category = "Fast Food",
                    HasDelivery = true,
                    ContactEmail = "contact@mcdonalds.com",
                    Dishes = [
                        new()
                        {
                            Name = "Big Mac",
                            Description = "Tasty burger",
                            Price = 5.99m
                        },
                         new()
                        {
                            Name = "Big Mac",
                            Description = "Tasty burger",
                            Price = 5.99m
                        }
                        ],
                    Address = new ()
                    {
                        City = "New York",
                        Street = "Broadway",
                        PostalCode = "10001"
                    }
                },
                new Restaurant()
                {
                    Name = "KFC",
                    Description = "Fast food restaurant",
                    Category = "Fast Food",
                    HasDelivery = true,
                    ContactEmail = "contact@kfs@mcdonalds.com",
                    Dishes = [
                        new()
                        {
                            Name = "Chicken wings",
                            Description = "Spicy chicken wings",
                            Price = 10.99m
                        },
                         new()
                        {
                            Name = "Chicken wings",
                            Description = "Spicy chicken wings",
                            Price = 10.99m
                        }
                        ],
                    Address = new()
                    {
                        City = "New York",
                        Street = "Broadway",
                        PostalCode = "10001"
                    }
                }
                ];
            return restaurants;
        }
    }
}
