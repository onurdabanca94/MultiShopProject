using Microsoft.EntityFrameworkCore;
using MultiShopProject.Comment.Entities;

namespace MultiShopProject.Comment.Context;

public class CommentContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1442\\MSSQLLocalDB;Database=MultiShopCommentDb;User=sa;Password=123456aA*;TrustServerCertificate=True;MultipleActiveResultSets=True");
    }
    public DbSet<UserComment> UserComments { get; set; }
}
