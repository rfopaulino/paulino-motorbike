using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Rental.Requests;
using Paulino.Motorbike.Domain.Rental.Validators;
using Paulino.Motorbike.Infra.CrossCutting.Exceptions;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Rental.Handlers
{
    public class SaveRentalHandler : IRequestHandler<SaveRentalRequest, BaseResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public SaveRentalHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse> Handle(SaveRentalRequest request, CancellationToken cancellationToken)
        {
            new SaveRentalValidator().RunValidate(request);

            var motorbike = await _dbContext.Motorbike.FirstOrDefaultAsync(x => x.Id == request.MotorbikeId);
            var driver = await _dbContext.Driver.FirstOrDefaultAsync(x => x.Id == request.DriverId);
            var plan = await _dbContext.Plan.FirstOrDefaultAsync(x => x.Id == request.PlanId);

            if (motorbike == null || driver == null || plan == null)
                throw new BadRequestException("Dados inválidos");

            var totalAmount = Math.Round(plan.DailyAmount * plan.TermDays, 2);

            var rental = new Infra.Data.EF.Entities.Rental(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(7), totalAmount, motorbike, driver, plan);
            await _dbContext.AddAsync(rental);
            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
