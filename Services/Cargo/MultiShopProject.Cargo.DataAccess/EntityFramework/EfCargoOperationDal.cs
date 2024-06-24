using MultiShopProject.Cargo.DataAccess.Abstract;
using MultiShopProject.Cargo.DataAccess.Concrete;
using MultiShopProject.Cargo.DataAccess.Repositories;
using MultiShopProject.Cargo.Entity.Concrete;

namespace MultiShopProject.Cargo.DataAccess.EntityFramework;

public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
{
    public EfCargoOperationDal(CargoContext context) : base(context)
    {

    }
}
