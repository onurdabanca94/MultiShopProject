using MediatR;
using MultiShopProject.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShopProject.Order.Application.Interfaces;
using MultiShopProject.Order.Domain.Entities;

namespace MultiShopProject.Order.Application.Features.Mediator.Handlers.OrderingCommands;

public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.OrderingId);
        values.OrderDate = request.OrderDate;
        values.UserId = request.UserId;
        values.TotalPrice = request.TotalPrice;
        await _repository.UpdateAsync(values);
    }
}
