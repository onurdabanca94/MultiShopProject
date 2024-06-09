using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShopProject.Discount.Entities;
using System.Data;

namespace MultiShopProject.Discount.Context;

public class DapperContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MultiShopDiscountDb; Trusted_Connection=True;");
    }
    public DbSet<Coupon> Coupons { get; set; }
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
