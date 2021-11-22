using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;
using WebApplication5.Models.Comments;

namespace WebApplication5.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins{ get; set; }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<RelationOrder> RelationOrders{ get; set; }
        public DbSet<MainComment> MainComments { get; set; }
        public DbSet<SubComment> SubComments{ get; set; }
    }
}
