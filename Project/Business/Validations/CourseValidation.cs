
using Business.IO.Course;
using FluentValidation;


namespace Business.Validations
{
    public class CourseValidation : AbstractValidator<CourseInput>
    {
        public CourseValidation()
        {
            RuleFor(f => f.Name)
              .NotEmpty().WithMessage("The {PropertyName} field must be provided");
        }
    }
}