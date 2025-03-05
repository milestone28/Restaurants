using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;


namespace Restaurants.Application.Restaurants.Validators
{
  public  class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
    {
        private List<string> validCategories = new List<string> { "Fast Food", "Traditional", "Vegetarian", "Vegan", "Italian", "Mexican", "Asian", "American", "Other" };
        public CreateRestaurantDtoValidator() 
        {
            RuleFor(x => x.Name).Length(3, 100);
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.Category)
                //.Must(x => validCategories.Contains(x))
                .Must(validCategories.Contains)
                .WithMessage("Please provide a valid category");
            //    .Custom((value, context) =>
            //{
            //    if (!validCategories.Contains(value))
            //    {
            //        context.AddFailure("Category", "Please provide a valid category");
            //    }
            //});
            RuleFor(x => x.ContactEmail).EmailAddress().WithMessage("Please provide a valid email address");
            RuleFor(x => x.PostalCode).Matches(@"^\d{2}-\d{3}$").WithMessage("Please provide a valid postal code (XX-XXX).");
        }
    }
}
