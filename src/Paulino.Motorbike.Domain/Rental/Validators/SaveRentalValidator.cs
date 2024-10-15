using FluentValidation;
using Paulino.Motorbike.Domain.Rental.Requests;

namespace Paulino.Motorbike.Domain.Rental.Validators
{
    public class SaveRentalValidator : AbstractValidator<SaveRentalRequest>
    {
        public SaveRentalValidator()
        {
            RuleFor(x => x.MotorbikeId).NotEmpty();
            RuleFor(x => x.MotorbikeId).GreaterThan(0);
            RuleFor(x => x.DriverId).NotEmpty();
            RuleFor(x => x.DriverId).GreaterThan(0);
            RuleFor(x => x.PlanId).NotEmpty();
            RuleFor(x => x.PlanId).GreaterThan(0);
        }
    }
}
