﻿using MultiShopProject.Cargo.DataAccess.Abstract;
using MultiShopProject.Cargo.DataAccess.Concrete;
using MultiShopProject.Cargo.DataAccess.Repositories;
using MultiShopProject.Cargo.Entity.Concrete;

namespace MultiShopProject.Cargo.DataAccess.EntityFramework;

public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
{
    private readonly CargoContext _cargoContext;
    public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
    {
        _cargoContext = cargoContext;
    }

    public CargoCustomer GetCargoCustomerById(string id)
    {
        var values = _cargoContext.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
        return values;
    }
}
