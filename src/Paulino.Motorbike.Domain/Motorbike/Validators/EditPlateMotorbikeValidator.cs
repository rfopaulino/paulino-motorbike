using FluentValidation;
using Paulino.Motorbike.Domain.Motorbike.Requests;

namespace Paulino.Motorbike.Domain.Motorbike.Validators
{
    public class EditPlateMotorbikeValidator : AbstractValidator<EditPlateMotorbikeRequest>
    {
        public EditPlateMotorbikeValidator()
        {
            RuleFor(x => x.MotorbikeId).NotEmpty();
            RuleFor(x => x.MotorbikeId).GreaterThan(0);
            RuleFor(x => x.Plate).NotEmpty();
            RuleFor(x => x.Plate).Length(7);
        }
    }
}
