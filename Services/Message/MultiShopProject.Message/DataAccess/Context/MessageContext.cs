using Microsoft.EntityFrameworkCore;
using MultiShopProject.Message.DataAccess.Entities;

namespace MultiShopProject.Message.DataAccess.Context
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {

        }
        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
