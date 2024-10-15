using MediatR;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Driver.Requests;
using Paulino.Motorbike.Domain.Driver.Validators;
using Paulino.Motorbike.Domain.Enums;
using Paulino.Motorbike.Infra.Data.EF;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Domain.Driver.Handlers
{
    public class SaveDriverHandler : IRequestHandler<SaveDriverRequest, BaseResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public SaveDriverHandler(IApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<BaseResponse> Handle(SaveDriverRequest request, CancellationToken cancellationToken)
        {
            new SaveDriverValidator().RunValidate(request);

            using (var transaction = _dbContext.BeginTransaction())
            {
                Document? document = null;
                if (request.CNHImage != null)
                {
                    document = new Document(request.CNHImage, "{}", (int)DocumentTypeEnum.CNH);
                    await _dbContext.AddAsync(document);
                    await _dbContext.SaveChangesAsync();
                }

                var cnh = new CNH(request.CNH, request.CNHTypeId, document);
                await _dbContext.AddAsync(cnh);
                await _dbContext.SaveChangesAsync();

                var driver = new Infra.Data.EF.Entities.Driver(request.Name, request.CNPJ, request.Birthdate, cnh);
                await _dbContext.AddAsync(driver);
                await _dbContext.SaveChangesAsync();

                transaction.Commit();
            }

            return new();
        }
    }
}
