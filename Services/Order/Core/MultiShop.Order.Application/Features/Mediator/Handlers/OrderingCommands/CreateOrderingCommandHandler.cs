using MediatR;
using MultiShopProject.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShopProject.Order.Application.Interfaces;
using MultiShopProject.Order.Domain.Entities;

namespace MultiShopProject.Order.Application.Features.Mediator.Handlers.OrderingCommands;

public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public CreateOrderingCommandHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Ordering
        {
            OrderDate = request.OrderDate,
            TotalPrice = request.TotalPrice,
            UserId = request.UserId
        });
    }
}
