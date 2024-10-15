using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Driver.Requests;
using Paulino.Motorbike.Domain.Driver.Validators;
using Paulino.Motorbike.Domain.Enums;
using Paulino.Motorbike.Infra.CrossCutting.Exceptions;
using Paulino.Motorbike.Infra.Data.EF;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Domain.Driver.Handlers
{
    public class SendCNHDriverHandler : IRequestHandler<SendCNHDriverRequest, BaseResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public SendCNHDriverHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse> Handle(SendCNHDriverRequest request, CancellationToken cancellationToken)
        {
            new SendCNHDriverValidator().RunValidate(request);

            using (var transaction = _dbContext.BeginTransaction())
            {
                var driver = await _dbContext.Driver
                    .Include(x => x.CNH)
                    .FirstOrDefaultAsync(x => x.Id == request.DriverId);

                if (driver == null)
                    throw new BadRequestException("Dados inválidos");

                var document = new Document(request.Image, "{}", (int)DocumentTypeEnum.CNH);
                driver.CNH.Document = document;
                await _dbContext.AddAsync(document);
                await _dbContext.SaveChangesAsync();

                transaction.Commit();
            }

            return new();
        }
    }
}
