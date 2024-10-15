﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Motorbike.Requests;
using Paulino.Motorbike.Domain.Motorbike.Responses;
using Paulino.Motorbike.Infra.CrossCutting.Exceptions;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class GetByIdMotorbikeHandler : IRequestHandler<GetByIdMotorbikeRequest, GetByIdMotorbikeResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetByIdMotorbikeHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetByIdMotorbikeResponse> Handle(GetByIdMotorbikeRequest request, CancellationToken cancellationToken)
        {
            var motorbike = await _dbContext.Motorbike
                .Where(x => x.Id == request.Id)
                .Select(x => new GetByIdMotorbikeResponse
                {
                    Year = x.Year,
                    Model = x.Model,
                    Plate = x.Plate
                })
                .FirstOrDefaultAsync();

            if (motorbike == null)
                throw new NotFoundException("Motorbike não encontrada");

            return motorbike;
        }
    }
}
