using Microsoft.EntityFrameworkCore;

namespace Aldebaran.Infrastructure;

public class AldebaranContext : DbContext   
{
    public AldebaranContext(DbContextOptions<AldebaranContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AldebaranContext).Assembly);
    }
}