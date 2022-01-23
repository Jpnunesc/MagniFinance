
using Business.IO.Course;
using Business.IO.Grade;
using FluentValidation;


namespace Business.Validations
{
    public class GradeValidation : AbstractValidator<GradeInput>
    {
        public GradeValidation()
        {
            RuleFor(f => f.StudentEntityId)
              .NotEmpty().WithMessage("The {PropertyName} field must be provided");
            RuleFor(f => f.SubjectEntityId)
              .NotEmpty().WithMessage("The {PropertyName} field must be provided");
        }
    }
}