using Microsoft.EntityFrameworkCore;

using Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Context;
using Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Queries;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelDeleteCommandHandler : DeleteCommandHandlerBase<TestModelDeleteCommand, TestModel, TestModelId, int, TestDbContext, TestEntity>
{
    public TestModelDeleteCommandHandler(IDbContextFactory<TestDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}
