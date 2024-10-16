using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Rental.Requests;
using Paulino.Motorbike.Domain.Rental.Responses;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Rental.Handlers
{
    public class GetRentalHandler : IRequestHandler<GetRentalRequest, List<GetRentalResponse>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetRentalHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<GetRentalResponse>> Handle(GetRentalRequest request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Rental.AsQueryable();

            if (request.MotorbikeId != null)
                query = query.Where(x => x.MotorbikeId == request.MotorbikeId);

            if (request.DriverId != null)
                query = query.Where(x => x.DriverId == request.DriverId);

            var rentals = query
                .Select(x => new GetRentalResponse
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    ExpectedEndDate = x.ExpectedEndDate,
                    OriginalAmount = x.OriginalAmount,
                    TotalAmount = x.TotalAmount,
                    PaidAmount = x.PaidAmount,
                    MotorbikeId = x.MotorbikeId,
                    DriverId = x.DriverId,
                    PlanId = x.PlanId
                })
                .ToListAsync();

            return rentals;
        }
    }
}
