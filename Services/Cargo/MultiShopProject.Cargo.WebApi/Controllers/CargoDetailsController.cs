using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Cargo.Business.Abstract;
using MultiShopProject.Cargo.Dto.Dtos.CargoDetailDtos;
using MultiShopProject.Cargo.Entity.Concrete;

namespace MultiShopProject.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController : ControllerBase
{
    private readonly ICargoDetailService _cargoDetailService;

    public CargoDetailsController(ICargoDetailService cargoDetailService)
    {
        _cargoDetailService = cargoDetailService;
    }

    [HttpGet]
    public IActionResult CargoDetailList()
    {
        var values = _cargoDetailService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
    {
        CargoDetail CargoDetail = new CargoDetail()
        {
            Barcode = createCargoDetailDto.Barcode,
            CargoCompanyId = createCargoDetailDto.CargoCompanyId,
            ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
            SenderCustomer = createCargoDetailDto.SenderCustomer
        };
        _cargoDetailService.TInsert(CargoDetail);
        return Ok("Cargo Detail has been created!");
    }

    [HttpDelete]
    public IActionResult RemoveCargoDetail(int id)
    {
        _cargoDetailService.TDelete(id);
        return Ok("Cargo Detail has been removed!");
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoDetailById(int id)
    {
        var values = _cargoDetailService.TGetById(id);
        return Ok(values);
    }

    [HttpPut]
    public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
    {
        //Cargo Company mapping için AutoMapper kullanılabilir. Manuel olarak işlenmesine örnek olması için yapılmıştır.
        CargoDetail CargoDetail = new CargoDetail()
        {
            Barcode = updateCargoDetailDto.Barcode,
            CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
            CargoDetailId = updateCargoDetailDto.CargoDetailId,
            ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
            SenderCustomer = updateCargoDetailDto.SenderCustomer
        };
        _cargoDetailService.TUpdate(CargoDetail);
        return Ok("Cargo Detail has been updated!");
    }
}
