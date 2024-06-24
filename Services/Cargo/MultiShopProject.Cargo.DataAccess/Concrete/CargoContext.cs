using Microsoft.EntityFrameworkCore;
using MultiShopProject.Cargo.Entity.Concrete;

namespace MultiShopProject.Cargo.DataAccess.Concrete;

public class CargoContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1441\\MSSQLLocalDB;Database=MultiShopCargoDb;User=sa;Password=123456aA*;TrustServerCertificate=True;MultipleActiveResultSets=True");
    }
    public DbSet<CargoCompany> CargoCompanies { get; set; }
    public DbSet<CargoDetail> CargoDetails { get; set; }
    public DbSet<CargoCustomer> CargoCustomers { get; set; }
    public DbSet<CargoOperation> CargoOperations { get; set; }
}
