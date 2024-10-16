using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Rental.Requests;
using Paulino.Motorbike.Domain.Rental.Responses;
using Paulino.Motorbike.Infra.CrossCutting.Exceptions;
using Paulino.Motorbike.Infra.Data.EF;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Domain.Rental.Handlers
{
    public class ReturnRentalHandler : IRequestHandler<ReturnRentalRequest, ReturnRentalResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public ReturnRentalHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ReturnRentalResponse> Handle(ReturnRentalRequest request, CancellationToken cancellationToken)
        {
            var totalAmount = 0m;
            var fineAmount = 0m;

            using (var transaction = _dbContext.BeginTransaction())
            {
                var rental = await _dbContext.Rental
                    .Include(x => x.Plan)
                    .FirstOrDefaultAsync(x => x.Id == request.RentalId);

                if (rental == null)
                    throw new BadRequestException("Dados inválidos");

                totalAmount = rental.TotalAmount;
                var remaningDays = (rental.EndDate.Date - request.Date.Date).Days;
                var usedDays = (request.Date.Date - rental.StartDate.Date).Days + 1;

                if (remaningDays > 0)
                {
                    fineAmount = (remaningDays * rental.Plan.DailyAmount) * rental.Plan.PercentageFine;
                    var fine = new RentalFine("Multa por entregar antes do prazo", fineAmount, rental);
                    await _dbContext.AddAsync(fine);
                    await _dbContext.SaveChangesAsync();

                    totalAmount = Math.Round(rental.Plan.DailyAmount * usedDays, 2) + fineAmount;
                    rental.TotalAmount = totalAmount;
                    rental.ExpectedEndDate = request.Date.ToUniversalTime();
                    await _dbContext.SaveChangesAsync();
                }
                else if (remaningDays < 0)
                {
                    var additionalDays = Math.Abs(remaningDays);
                    totalAmount = rental.OriginalAmount + Math.Round(rental.Plan.AdditionalDailyAmount * additionalDays, 2);
                    rental.TotalAmount = totalAmount;
                    rental.ExpectedEndDate = request.Date.ToUniversalTime();
                    await _dbContext.SaveChangesAsync();
                }
                else
                    totalAmount = rental.TotalAmount;

                transaction.Commit();
            }

            return new ReturnRentalResponse(totalAmount, fineAmount);
        }
    }
}
