using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Cargo.Business.Abstract;
using MultiShopProject.Cargo.Dto.Dtos.CargoCompanyDtos;
using MultiShopProject.Cargo.Entity.Concrete;

namespace MultiShopProject.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController : ControllerBase
{
    private readonly ICargoCompanyService _cargoCompanyService;

    public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
    {
        _cargoCompanyService = cargoCompanyService;
    }

    [HttpGet]
    public IActionResult CargoCompanyList()
    {
        var values = _cargoCompanyService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
    {
        CargoCompany cargoCompany = new CargoCompany()
        {
            CargoCompanyName = createCargoCompanyDto.CargoCompanyName
        };
        _cargoCompanyService.TInsert(cargoCompany);
        return Ok("Cargo Company has been created!");
    }

    [HttpDelete]
    public IActionResult RemoveCargoCompany(int id)
    {
        _cargoCompanyService.TDelete(id);
        return Ok("Cargo Company has been removed!");
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCompanyById(int id)
    {
        var values = _cargoCompanyService.TGetById(id);
        return Ok(values);
    }

    [HttpPut]
    public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        //Cargo Company mapping için AutoMapper kullanılabilir. Manuel olarak işlenmesine örnek olması için yapılmıştır.
        CargoCompany cargoCompany = new CargoCompany()
        {
            CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
            CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
        };
        _cargoCompanyService.TUpdate(cargoCompany);
        return Ok("Cargo Company has been updated!");
    }
}
