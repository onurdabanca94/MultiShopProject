using MultiShopProject.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShopProject.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShopProject.Order.Application.Interfaces;
using MultiShopProject.Order.Domain.Entities;

namespace MultiShopProject.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler
{
    private readonly IRepository<Address> _repository;

    public GetAddressByIdQueryHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }
    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
    {
        var values = await _repository.GetByIdAsync(query.Id);

        return new GetAddressByIdQueryResult
        {
            AddressId = values.AddressId,
            City = values.City,
            Detail = values.DetailFirst,
            Disctrict = values.Disctrict,
            UserId = values.UserId
        };
    }
}
