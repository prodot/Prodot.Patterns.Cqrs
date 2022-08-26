using Microsoft.EntityFrameworkCore;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelCountQueryHandler
    : CountQueryHandlerBase<TestModelCountQuery, TestModel, TestModelId, int, TestDbContext, TestEntity, int>
{
    public TestModelCountQueryHandler(IDbContextFactory<TestDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}
