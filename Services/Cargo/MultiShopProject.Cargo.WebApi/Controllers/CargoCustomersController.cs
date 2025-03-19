﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Cargo.Business.Abstract;
using MultiShopProject.Cargo.Dto.Dtos.CargoCustomerDtos;
using MultiShopProject.Cargo.Entity.Concrete;

namespace MultiShopProject.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController : ControllerBase
{
    private readonly ICargoCustomerService _cargoCustomerService;

    public CargoCustomersController(ICargoCustomerService cargoCustomerService)
    {
        _cargoCustomerService = cargoCustomerService;
    }

    [HttpGet]
    public IActionResult CargoCustomerList()
    {
        var values = _cargoCustomerService.TGetAll();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCustomerById(int id)
    {
        var value = _cargoCustomerService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
    {
        CargoCustomer cargoCustomer = new CargoCustomer()
        {
            Address = createCargoCustomerDto.Address,
            City = createCargoCustomerDto.City,
            District = createCargoCustomerDto.District,
            Email = createCargoCustomerDto.Email,
            Name = createCargoCustomerDto.Name,
            Phone = createCargoCustomerDto.Phone,
            Surname = createCargoCustomerDto.Surname,
            UserCustomerId = createCargoCustomerDto.UserCustomerId,
        };
        _cargoCustomerService.TInsert(cargoCustomer);
        return Ok("Cargo Customer has been created!");
    }

    [HttpDelete]
    public IActionResult RemoveCargoCustomer(int id)
    {
        _cargoCustomerService.TDelete(id);
        return Ok("Cargo Customer has been removed!");
    }

    [HttpPut]
    public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        CargoCustomer cargoCustomer = new CargoCustomer()
        {
            Address = updateCargoCustomerDto.Address,
            CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
            City = updateCargoCustomerDto.City,
            District = updateCargoCustomerDto.District,
            Email = updateCargoCustomerDto.Email,
            Name = updateCargoCustomerDto.Name,
            Phone = updateCargoCustomerDto.Phone,
            Surname = updateCargoCustomerDto.Surname,
            UserCustomerId = updateCargoCustomerDto.UserCustomerId,
        };
        _cargoCustomerService.TUpdate(cargoCustomer);
        return Ok("Cargo Customer has been updated!");
    }
}
