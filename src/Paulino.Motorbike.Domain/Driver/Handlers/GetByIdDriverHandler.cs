using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Driver.Requests;
using Paulino.Motorbike.Domain.Driver.Responses;
using Paulino.Motorbike.Infra.CrossCutting.Exceptions;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Driver.Handlers
{
    public class GetByIdDriverHandler : IRequestHandler<GetByIdDriverRequest, GetByIdDriverResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetByIdDriverHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetByIdDriverResponse> Handle(GetByIdDriverRequest request, CancellationToken cancellationToken)
        {
            var driver = await _dbContext.Driver
                .Include(x => x.CNH)
                .ThenInclude(x => x.Document)
                .Where(x => x.Id == request.Id)
                .Select(x => new GetByIdDriverResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    CNPJ = x.CNPJ,
                    Birthdate = x.Birthdate,
                    CNHNumber = x.CNH.Number,
                    CNHImage = x.CNH.Document.Image
                })
                .FirstOrDefaultAsync();

            if (driver == null)
                throw new NotFoundException("Entregador não encontrado");

            return driver;
        }
    }
}
