using MultiShopProject.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShopProject.Order.Application.Interfaces;
using MultiShopProject.Order.Domain.Entities;

namespace MultiShopProject.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateOrderDetailCommand command)
    {
        await _repository.CreateAsync(new OrderDetail
        {
            ProductAmount = command.ProductAmount,
            ProductName = command.ProductName,
            OrderingId = command.OrderingId,
            ProductId = command.ProductId,
            ProductPrice = command.ProductPrice,
            ProductTotalPrice = command.ProductTotalPrice
        });
    }
}
