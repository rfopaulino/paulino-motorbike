using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Motorbike.Requests;
using Paulino.Motorbike.Domain.Motorbike.Validators;
using Paulino.Motorbike.Infra.CrossCutting.Exception;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class EditPlateMotorbikeHandler : IRequestHandler<EditPlateMotorbikeRequest, BaseResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public EditPlateMotorbikeHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse> Handle(EditPlateMotorbikeRequest request, CancellationToken cancellationToken)
        {
            new EditPlateMotorbikeValidator().RunValidate(request);

            var motorbike = await _dbContext.Motorbike.FirstOrDefaultAsync(x => x.Id == request.MotorbikeId);

            if (motorbike == null)
                throw new BadRequestException("Dados inválidos");

            motorbike.Plate = request.PlateUnformatted;
            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
