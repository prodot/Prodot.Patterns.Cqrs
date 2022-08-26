using Microsoft.EntityFrameworkCore;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelStrongIdCountQueryHandler : CountQueryHandlerBase<TestModelStrongIdCountQuery, TestModelStrongId, TestModelStrongId.Identifier, int, TestDbContext, TestEntityStrongId, TestEntityStrongId.Identifier>
{
    public TestModelStrongIdCountQueryHandler(IDbContextFactory<TestDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}
