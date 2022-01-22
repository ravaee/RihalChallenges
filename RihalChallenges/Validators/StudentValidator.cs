using Common.Models;
using FluentValidation;

namespace RihalChallenges.Validators
{
    public class StudentValidator : AbstractValidator<StudentDTO>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 100);


            RuleFor(x => ((x == null) ? DateTime.Now : x.BirthDate))
                .NotEmpty()
                .ExclusiveBetween(new DateTime(1900,01,01), DateTime.Now);

            RuleFor(x => x.ClassId)
                .NotEmpty();

            RuleFor(x => x.CountryId)
                .NotEmpty();

        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {

            var result = await ValidateAsync(ValidationContext<StudentDTO>.CreateWithOptions((StudentDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
