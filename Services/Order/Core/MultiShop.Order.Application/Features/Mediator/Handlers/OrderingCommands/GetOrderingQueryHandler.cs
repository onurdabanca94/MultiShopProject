using MediatR;
using MultiShopProject.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShopProject.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShopProject.Order.Application.Interfaces;
using MultiShopProject.Order.Domain.Entities;

namespace MultiShopProject.Order.Application.Features.Mediator.Handlers.OrderingCommands;

public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    private readonly IRepository<Ordering> _repository;

    public GetOrderingQueryHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken) //sayfa yüklenirken uzun sürüp kapatılırsa cancel işlemi
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetOrderingQueryResult
        {
            OrderingId = x.OrderingId,
            OrderDate = x.OrderDate,
            TotalPrice = x.TotalPrice,
            UserId = x.UserId,
        }).ToList();
    }
}
