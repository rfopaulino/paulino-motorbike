using MediatR;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Driver.Requests;
using Paulino.Motorbike.Domain.Driver.Validators;
using Paulino.Motorbike.Infra.CrossCutting.Exceptions;
using Paulino.Motorbike.Infra.Data.Dapper.Base;
using Paulino.Motorbike.Infra.Data.Dapper.Dtos;
using Paulino.Motorbike.Infra.Data.Dapper.Queries;
using Paulino.Motorbike.Infra.Data.EF;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Domain.Driver.Handlers
{
    public class SaveDriverHandler : IRequestHandler<SaveDriverRequest, BaseResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IDapperRepository _dapper;

        public SaveDriverHandler(IApplicationDbContext context, IDapperRepository dapper)
        {
            _dbContext = context;
            _dapper = dapper;
        }

        public async Task<BaseResponse> Handle(SaveDriverRequest request, CancellationToken cancellationToken)
        {
            new SaveDriverValidator().RunValidate(request);

            var driverByCNPJ = await _dapper.QueryFirstOrDefaultAsync<GetDriverByCNPJDapperQueryDto>(new GetDriverByCNPJDapperQuery(request.CNPJUnformatted));

            if (driverByCNPJ != null)
                throw new BadRequestException("CNPJ já cadastrado");

            var cnhByNumber = await _dapper.QueryFirstOrDefaultAsync<GetCNHByNumberDapperQueryDto>(new GetCNHByNumberDapperQuery(request.CNPJUnformatted));

            if (cnhByNumber != null)
                throw new BadRequestException("CNH já cadastrado");


            using (var transaction = _dbContext.BeginTransaction())
            {
                var cnh = new CNH(request.CNH, request.CNHTypeId, null);
                await _dbContext.AddAsync(cnh);
                await _dbContext.SaveChangesAsync();

                var driver = new Infra.Data.EF.Entities.Driver(request.Name, request.CNPJUnformatted, request.Birthdate, cnh);
                await _dbContext.AddAsync(driver);
                await _dbContext.SaveChangesAsync();

                transaction.Commit();
            }

            return new();
        }
    }
}
