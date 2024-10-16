using MediatR;
using Paulino.Motorbike.Domain.Motorbike.Requests;
using Paulino.Motorbike.Infra.Data.EF;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class AddMotorbike2024Handler : IRequestHandler<AddMotorbike2024Request, Unit>
    {
        private readonly ApplicationDbContext _dbContext;

        public AddMotorbike2024Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddMotorbike2024Request request, CancellationToken cancellationToken)
        {
            var motorbike = new Motorbike2024(request.Message);
            await _dbContext.Motorbike2024.AddAsync(motorbike);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
