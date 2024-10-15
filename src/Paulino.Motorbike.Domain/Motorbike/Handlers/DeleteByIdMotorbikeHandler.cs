using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Motorbike.Requests;
using Paulino.Motorbike.Infra.CrossCutting.Exceptions;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class DeleteByIdMotorbikeHandler : IRequestHandler<DeleteByIdMotorbikeRequest, Unit>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteByIdMotorbikeHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteByIdMotorbikeRequest request, CancellationToken cancellationToken)
        {
            var motorbike = await _dbContext.Motorbike.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (motorbike == null)
                throw new BadRequestException("Dados inválidos");

            _dbContext.Motorbike.Remove(motorbike);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
