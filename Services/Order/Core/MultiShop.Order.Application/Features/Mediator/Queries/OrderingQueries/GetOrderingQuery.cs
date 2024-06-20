using MediatR;
using MultiShopProject.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MultiShopProject.Order.Application.Features.Mediator.Queries.OrderingQueries;

public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
{

}
