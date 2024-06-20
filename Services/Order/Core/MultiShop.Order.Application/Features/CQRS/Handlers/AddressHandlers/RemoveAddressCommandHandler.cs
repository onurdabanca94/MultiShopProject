using MultiShopProject.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShopProject.Order.Application.Interfaces;
using MultiShopProject.Order.Domain.Entities;

namespace MultiShopProject.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class RemoveAddressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public RemoveAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveAddressCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        await _repository.DeleteAsync(value);
    }
}
