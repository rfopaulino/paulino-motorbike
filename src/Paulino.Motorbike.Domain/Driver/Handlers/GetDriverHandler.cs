using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Driver.Requests;
using Paulino.Motorbike.Domain.Driver.Responses;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Driver.Handlers
{
    public class GetDriverHandler : IRequestHandler<GetDriverRequest, List<GetDriverResponse>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetDriverHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetDriverResponse>> Handle(GetDriverRequest request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Driver
                .Include(x => x.CNH)
                .ThenInclude(x => x.Document)
                .AsQueryable();

            if (request.CNPJ != null)
                query = query.Where(x => x.CNPJ == request.CNPJ);

            if (request.CNH != null)
                query = query.Where(x => x.CNH.Number == request.CNH);

            var drivers = await query
                .Select(x => new GetDriverResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    CNPJ = x.CNPJ,
                    Birthdate = x.Birthdate,
                    CNHNumber = x.CNH.Number,
                    CNHImage = x.CNH.Document.Image
                })
                .ToListAsync();

            return drivers;
        }
    }
}
