using MediatR;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Motorbike.Requests;
using Paulino.Motorbike.Domain.Motorbike.Validators;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class SaveMotorbikeHandler : IRequestHandler<SaveMotorbikeRequest, BaseResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public SaveMotorbikeHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse> Handle(SaveMotorbikeRequest request, CancellationToken cancellationToken)
        {
            new SaveMotorbikeValidator().RunValidate(request);

            var motorbike = new Infra.Data.EF.Entities.Motorbike(request.Year, request.Model, request.Plate);
            await _dbContext.AddAsync(motorbike);
            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
