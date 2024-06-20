using Microsoft.EntityFrameworkCore;
using MultiShopProject.Order.Domain.Entities;

namespace MultiShopProject.Order.Persistence.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1440\\MSSQLLocalDB;Database=MultiShopOrderDb;User=sa;Password=123456aA*;TrustServerCertificate=True;MultipleActiveResultSets=True");
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
}
