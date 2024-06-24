using MultiShopProject.Cargo.DataAccess.Abstract;
using MultiShopProject.Cargo.DataAccess.Concrete;
using MultiShopProject.Cargo.DataAccess.Repositories;
using MultiShopProject.Cargo.Entity.Concrete;

namespace MultiShopProject.Cargo.DataAccess.EntityFramework;

public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
{
    public EfCargoCustomerDal(CargoContext context) : base(context)
    {

    }
}
