﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Rental.Requests;
using Paulino.Motorbike.Domain.Rental.Responses;
using Paulino.Motorbike.Infra.CrossCutting.Exception;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Rental.Handlers
{
    public class GetByIdRentalHandler : IRequestHandler<GetByIdRentalRequest, GetByIdRentalResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetByIdRentalHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetByIdRentalResponse> Handle(GetByIdRentalRequest request, CancellationToken cancellationToken)
        {
            var rental = await _dbContext.Rental
                .Where(x => x.Id == request.Id)
                .Select(x => new GetByIdRentalResponse
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
                .FirstOrDefaultAsync();

            if (rental == null)
                throw new NotFoundException("Locação não encontrada");

            return rental;
        }
    }
}
