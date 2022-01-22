using Common.DTOs;
using Common.Models;
using FluentValidation;

namespace RihalChallenges.Validators
{
    public class UserValidator : AbstractValidator<LoginDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty();

                

        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<LoginDto>.CreateWithOptions((LoginDto)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
