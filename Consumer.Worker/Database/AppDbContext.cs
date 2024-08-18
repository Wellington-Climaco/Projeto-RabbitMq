using Consumer.Worker.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consumer.Worker.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
