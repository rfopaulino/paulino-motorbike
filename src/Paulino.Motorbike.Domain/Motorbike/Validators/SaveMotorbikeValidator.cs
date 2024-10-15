using FluentValidation;
using Paulino.Motorbike.Domain.Motorbike.Requests;

namespace Paulino.Motorbike.Domain.Motorbike.Validators
{
    public class SaveMotorbikeValidator : AbstractValidator<SaveMotorbikeRequest>
    {
        public SaveMotorbikeValidator()
        {
            RuleFor(x => x.Year).NotEmpty();
            RuleFor(x => x.Year).GreaterThanOrEqualTo(2014);
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.Plate).NotEmpty();
            RuleFor(x => x.Plate).Length(7);
        }
    }
}
