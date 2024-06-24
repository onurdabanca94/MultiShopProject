using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Cargo.Business.Abstract;
using MultiShopProject.Cargo.Dto.Dtos.CargoOperationDtos;
using MultiShopProject.Cargo.Entity.Concrete;

namespace MultiShopProject.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController : ControllerBase
{
    private readonly ICargoOperationService _cargoOperationService;

    public CargoOperationsController(ICargoOperationService cargoOperationService)
    {
        _cargoOperationService = cargoOperationService;
    }

    [HttpGet]
    public IActionResult CargoOperationList()
    {
        var values = _cargoOperationService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
    {
        CargoOperation CargoOperation = new CargoOperation()
        {
            Barcode = createCargoOperationDto.Barcode,
            Description = createCargoOperationDto.Description,
            OperationDate = createCargoOperationDto.OperationDate
        };
        _cargoOperationService.TInsert(CargoOperation);
        return Ok("Cargo Operation has been created!");
    }

    [HttpDelete]
    public IActionResult RemoveCargoOperation(int id)
    {
        _cargoOperationService.TDelete(id);
        return Ok("Cargo Operation has been removed!");
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoOperationById(int id)
    {
        var values = _cargoOperationService.TGetById(id);
        return Ok(values);
    }

    [HttpPut]
    public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
    {
        //Cargo Company mapping için AutoMapper kullanılabilir. Manuel olarak işlenmesine örnek olması için yapılmıştır.
        CargoOperation CargoOperation = new CargoOperation()
        {
            Barcode = updateCargoOperationDto.Barcode,
            Description = updateCargoOperationDto.Description,
            CargoOperationId = updateCargoOperationDto.CargoOperationId,
            OperationDate = updateCargoOperationDto.OperationDate
        };
        _cargoOperationService.TUpdate(CargoOperation);
        return Ok("Cargo Operation has been updated!");
    }
}
