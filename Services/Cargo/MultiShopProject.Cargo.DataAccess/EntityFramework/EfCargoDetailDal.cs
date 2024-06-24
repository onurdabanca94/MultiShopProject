using MultiShopProject.Cargo.DataAccess.Abstract;
using MultiShopProject.Cargo.DataAccess.Concrete;
using MultiShopProject.Cargo.DataAccess.Repositories;
using MultiShopProject.Cargo.Entity.Concrete;

namespace MultiShopProject.Cargo.DataAccess.EntityFramework;

public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
{
    public EfCargoDetailDal(CargoContext context) : base(context)
    {

    }
}
