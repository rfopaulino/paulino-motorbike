using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Motorbike.Requests;
using Paulino.Motorbike.Domain.Motorbike.Responses;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class GetMotorbikeHandler : IRequestHandler<GetMotorbikeRequest, List<GetMotorbikeResponse>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetMotorbikeHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetMotorbikeResponse>> Handle(GetMotorbikeRequest request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Motorbike.AsQueryable();

            if (request.Year != null)
                query = query.Where(x => x.Year == request.Year);

            if (request.Model != null)
                query = query.Where(x => x.Model == request.Model);

            if (request.Plate != null)
                query = query.Where(x => x.Plate == request.Plate);

            var motorbikes = await query
                .Select(x => new GetMotorbikeResponse
                {
                    Year = x.Year,
                    Model = x.Model,
                    Plate = x.Plate
                })
                .ToListAsync();

            return motorbikes;
        }
    }
}
