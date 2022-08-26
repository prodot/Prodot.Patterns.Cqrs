using Microsoft.EntityFrameworkCore;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Context;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public DbSet<TestEntity> Entities { get; set; } = default!;

    public DbSet<TestEntityStrongId> StrongIdEntities { get; set; } = default!;

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<TestEntityStrongId.Identifier>()
            .HaveConversion(typeof(TestEntityStrongId.Identifier.EfCoreValueConverter));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestEntityStrongId>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<TestEntityStrongId>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
    }
}
