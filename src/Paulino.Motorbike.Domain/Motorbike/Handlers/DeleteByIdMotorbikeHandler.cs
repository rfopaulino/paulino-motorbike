using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Motorbike.Requests;
using Paulino.Motorbike.Infra.CrossCutting.Exceptions;
using Paulino.Motorbike.Infra.Data.Dapper.Base;
using Paulino.Motorbike.Infra.Data.Dapper.Dtos;
using Paulino.Motorbike.Infra.Data.Dapper.Queries;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class DeleteByIdMotorbikeHandler : IRequestHandler<DeleteByIdMotorbikeRequest, Unit>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IDapperRepository _dapper;

        public DeleteByIdMotorbikeHandler(IApplicationDbContext dbContext, IDapperRepository dapper)
        {
            _dbContext = dbContext;
            _dapper = dapper;
        }

        public async Task<Unit> Handle(DeleteByIdMotorbikeRequest request, CancellationToken cancellationToken)
        {
            var motorbike = await _dbContext.Motorbike.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (motorbike == null)
                throw new BadRequestException("Dados inválidos");

            var activeRentals = await _dapper.QueryAsync<GetActiveRentalsByMotorbikeDapperQueryDto>(new GetActiveRentalsByMotorbikeDapperQuery(request.Id));

            if ((activeRentals?.Count() ?? 0) > 0)
                throw new BadRequestException("Tem locação ativa");

            _dbContext.Motorbike.Remove(motorbike);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
