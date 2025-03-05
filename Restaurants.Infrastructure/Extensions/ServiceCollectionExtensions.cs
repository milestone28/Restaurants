﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RestaurantsDb");

            services.AddDbContext<RestaurantDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>(); // Creating a scoped service for the RestaurantSeeder
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>(); // Creating a scoped service for the RestaurantsRepository
        }
    }
}
