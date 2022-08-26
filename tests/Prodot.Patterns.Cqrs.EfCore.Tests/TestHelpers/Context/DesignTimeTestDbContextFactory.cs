using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Context;

public class DesignTimeTestDbContextFactory : IDesignTimeDbContextFactory<TestDbContext>
{
    public TestDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseSqlite($"DataSource=file:memdbDesignTime?mode=memory&cache=shared")
            .Options;
        return new TestDbContext(options);
    }
}
