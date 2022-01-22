
using Business.IO.Subject;
using FluentValidation;


namespace Business.Validations
{
    public class SubjectValidation : AbstractValidator<SubjectInput>
    {
        public SubjectValidation()
        {
            RuleFor(f => f.Name)
              .NotEmpty().WithMessage("The {PropertyName} field must be provided");
            RuleFor(f => f.Average)
                .NotEmpty().WithMessage("The {PropertyName} field must be provided");
        }
    }
}