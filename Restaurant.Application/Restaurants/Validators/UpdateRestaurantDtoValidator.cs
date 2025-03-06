using FluentValidation;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;


namespace Restaurants.Application.Restaurants.Validators
{
  public  class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator() 
        {
            RuleFor(x => x.Name).Length(3, 100);
        }
    }
}
