
using Business.IO.Teacher;
using FluentValidation;


namespace Business.Validations
{
    public class TeacherValidation : AbstractValidator<TeacherInput>
    {
        public TeacherValidation()
        {
            RuleFor(f => f.Name)
              .NotEmpty().WithMessage("The {PropertyName} field must be provided");
            RuleFor(f => f.Remuneration)
             .NotEmpty().WithMessage("The {PropertyName} field must be provided");
            RuleFor(f => f.BirthDate)
                 .NotEmpty().WithMessage("The birth date field must be provided");
        }
    }
}