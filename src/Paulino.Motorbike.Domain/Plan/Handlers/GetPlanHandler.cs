using MediatR;
using Microsoft.EntityFrameworkCore;
using Paulino.Motorbike.Domain.Plan.Requests;
using Paulino.Motorbike.Domain.Plan.Responses;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.Domain.Plan.Handlers
{
    public class GetPlanHandler : IRequestHandler<GetPlanRequest, List<GetPlanResponse>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetPlanHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<GetPlanResponse>> Handle(GetPlanRequest request, CancellationToken cancellationToken)
        {
            var plans = _dbContext.Plan
                .Select(x => new GetPlanResponse
                {
                    Id = x.Id,
                    TermDays = x.TermDays,
                    DailyAmount = x.DailyAmount,
                    AdditionalDaily = x.AdditionalDailyAmount,
                    PercentageFine = x.PercentageFine,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            return plans;
        }
    }
}
