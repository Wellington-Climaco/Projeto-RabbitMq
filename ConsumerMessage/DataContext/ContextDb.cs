using Microsoft.EntityFrameworkCore;

namespace ConsumerMessage;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {       
    }

    DbSet<Cliente> Clientes { get; set;}

}
