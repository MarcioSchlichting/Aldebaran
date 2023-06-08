using Microsoft.EntityFrameworkCore;

namespace Aldebaran.Infrastructure;

public class AldebaranContext : DbContext   
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AldebaranContext).Assembly);
    }
}