using FluentValidation;
using RestaurantAPI2.Entities;

namespace RestaurantAPI2.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {

        public RegisterUserDtoValidator(RestaurantDbContext dbContext)
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress(); //pole wymagane
            RuleFor(e => e.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(e => e.ConfirmPassword).Equal(e => e.Password);

            RuleFor(e => e.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Email in use");
                    }
                });

        }
    }
}
