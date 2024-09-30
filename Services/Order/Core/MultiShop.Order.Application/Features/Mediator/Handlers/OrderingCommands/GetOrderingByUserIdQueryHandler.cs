using MediatR;
using MultiShopProject.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShopProject.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShopProject.Order.Application.Interfaces;

namespace MultiShopProject.Order.Application.Features.Mediator.Handlers.OrderingCommands;

public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
{
    private readonly IOrderingRepository _orderingRepository;

    public GetOrderingByUserIdQueryHandler(IOrderingRepository orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
    {
        var values = _orderingRepository.GetOrderingByUserId(request.Id);
        return values.Select(x => new GetOrderingByUserIdQueryResult
        {
            OrderDate = x.OrderDate,
            OrderingId = x.OrderingId,
            UserId = x.UserId,
            TotalPrice = x.TotalPrice,
        }).ToList();
    }
}
