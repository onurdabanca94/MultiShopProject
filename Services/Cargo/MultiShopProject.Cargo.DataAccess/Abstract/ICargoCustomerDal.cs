using MultiShopProject.Cargo.Entity.Concrete;

namespace MultiShopProject.Cargo.DataAccess.Abstract;

public interface ICargoCustomerDal : IGenericDal<CargoCustomer>
{
    CargoCustomer GetCargoCustomerById(string id); //UserCustomerId'ye göre işlem yapacağımız için string alıyoruz.
}
