
using Business.IO.Student;
using FluentValidation;


namespace Business.Validations
{
    public class StudentValidation : AbstractValidator<StudentInput>
    {
        public StudentValidation()
        {
            RuleFor(f => f.Name)
              .NotEmpty().WithMessage("The {PropertyName} field must be provided");
            RuleFor(f => f.IdCourse)
                .NotEmpty().WithMessage("The Course field must be provided");
            RuleFor(f => f.BirthDate)
                 .NotEmpty().WithMessage("The birth date field must be provided");
        }
    }
}