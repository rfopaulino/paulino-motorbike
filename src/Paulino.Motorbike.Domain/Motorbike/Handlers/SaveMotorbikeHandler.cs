using MediatR;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Motorbike.Requests;
using Paulino.Motorbike.Domain.Motorbike.Validators;
using Paulino.Motorbike.Infra.CrossCutting.Exception;
using Paulino.Motorbike.Infra.Data.Dapper.Base;
using Paulino.Motorbike.Infra.Data.Dapper.Dtos;
using Paulino.Motorbike.Infra.Data.Dapper.Queries;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class SaveMotorbikeHandler : IRequestHandler<SaveMotorbikeRequest, BaseResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IDapperRepository _dapper;

        public SaveMotorbikeHandler(IApplicationDbContext dbContext, IDapperRepository dapper)
        {
            _dbContext = dbContext;
            _dapper = dapper;
        }

        public async Task<BaseResponse> Handle(SaveMotorbikeRequest request, CancellationToken cancellationToken)
        {
            new SaveMotorbikeValidator().RunValidate(request);

            var motorbikeByPlate = await _dapper.QueryFirstOrDefaultAsync<GetMotorbikeByPlateDapperQueryDto>(new GetMotorbikeByPlateDapperQuery(request.PlateUnformatted));

            if (motorbikeByPlate != null)
                throw new BadRequestException("Placa já cadastrada");

            var motorbike = new Infra.Data.EF.Entities.Motorbike(request.Year, request.Model, request.PlateUnformatted);
            await _dbContext.AddAsync(motorbike);
            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
