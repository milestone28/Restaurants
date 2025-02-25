
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence
{
  internal  class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : DbContext(options)
    {
        internal DbSet<Restaurant> Restaurants { get; set; }
        internal DbSet<Dish> Dishes { get; set; }

        //override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if(!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=garynas224plus\\MSSQL-SERVER,1433;Database=RestaurantsDb;User=sa;Password=DataSeasoning09021989;TrustServerCertificate=True", optionsBuilder => optionsBuilder.EnableRetryOnFailure());   
        //    }
               
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("TutorialAppSchema");
            //modelBuilder.Entity<User>().ToTable("Users", "TutorialAppSchema").HasKey(u => u.UserId);
            //modelBuilder.Entity<UserSalary>().HasKey(u => u.UserId);
            //modelBuilder.Entity<UserJobInfo>().HasKey(u => u.UserId);

            base.OnModelCreating(modelBuilder); //this will create the tables
            modelBuilder.Entity<Restaurant>().OwnsOne(r => r.Address);
            modelBuilder.Entity<Restaurant>().HasMany(r => r.Dishes).WithOne().HasForeignKey(d => d.RestaurantId);
        }
    }
}
