using MediatR;
using Paulino.Motorbike.Domain.Plan.Responses;

namespace Paulino.Motorbike.Domain.Plan.Requests
{
    public class GetPlanRequest : IRequest<List<GetPlanResponse>>
    {
    }
}
