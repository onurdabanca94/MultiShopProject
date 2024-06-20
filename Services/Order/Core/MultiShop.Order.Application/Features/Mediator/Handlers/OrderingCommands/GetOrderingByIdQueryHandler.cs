using MediatR;
using MultiShopProject.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShopProject.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShopProject.Order.Application.Interfaces;
using MultiShopProject.Order.Domain.Entities;

namespace MultiShopProject.Order.Application.Features.Mediator.Handlers.OrderingCommands;

public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    private readonly IRepository<Ordering> _repository;

    public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        return new GetOrderingByIdQueryResult
        {
            OrderDate = values.OrderDate,
            OrderingId = values.OrderingId,
            TotalPrice = values.TotalPrice,
            UserId = values.UserId,
        };
    }
}
