using MultiShopProject.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShopProject.Order.Application.Interfaces;
using MultiShopProject.Order.Domain.Entities;

namespace MultiShopProject.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public UpdateAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAddressCommand command)
    {
        var values = await _repository.GetByIdAsync(command.AddressId);
        values.Detail = command.Detail;
        values.Disctrict = command.Disctrict;
        values.City = command.City;
        values.UserId = command.UserId;
        await _repository.UpdateAsync(values);
    }
}
