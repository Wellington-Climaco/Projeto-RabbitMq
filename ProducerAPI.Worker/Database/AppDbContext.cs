using Microsoft.EntityFrameworkCore;
using ProducerAPI.Worker.Entities;

namespace ProducerAPI.Worker.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
