using Common.Models;
using FluentValidation;

namespace RihalChallenges.Validators
{
    public class ClassValidator : AbstractValidator<ClassDTO>
    {
        public ClassValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(6, 30);

        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ClassDTO>.CreateWithOptions((ClassDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
