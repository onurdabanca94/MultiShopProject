using MultiShopProject.Cargo.Entity.Concrete;

namespace MultiShopProject.Cargo.Business.Abstract;

public interface ICargoCustomerService : IGenericService<CargoCustomer>
{
    CargoCustomer TGetCargoCustomerById(string id); //başına T koymamızın sebebi business metodlar ile dataAccess metodları karışmasın.
}
