using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsumerMessage.DataContext;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ContextDb>
{
    public ContextDb CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ContextDb>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Usuarios;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");

        return new ContextDb(optionsBuilder.Options);
    }
}
