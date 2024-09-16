using MultiShopProject.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShopProject.Order.Application.Interfaces;
using MultiShopProject.Order.Domain.Entities;

namespace MultiShopProject.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler
{
    private readonly IRepository<Address> _repository;
    public CreateAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateAddressCommand createAddressCommand)
    {
        await _repository.CreateAsync(new Address
        {
            City = createAddressCommand.City,
            DetailFirst = createAddressCommand.DetailFirst,
            Disctrict = createAddressCommand.Disctrict,
            UserId = createAddressCommand.UserId,
            Country = createAddressCommand.Country,
            Description = createAddressCommand.Description,
            DetailSecond = createAddressCommand.DetailSecond,
            Email = createAddressCommand.Email,
            Name = createAddressCommand.Name,
            Surname = createAddressCommand.Surname,
            Phone = createAddressCommand.Phone,
            ZipCode = createAddressCommand.ZipCode
        });
    }
}
