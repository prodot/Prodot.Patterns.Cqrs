using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelStrongIdCreateQueryHandler
    : CreateQueryHandlerBase<TestModelStrongIdCreateQuery, TestModelStrongId, TestModelStrongId.Identifier, int, TestDbContext, TestEntityStrongId, TestEntityStrongId.Identifier>
{
    public TestModelStrongIdCreateQueryHandler(IMapper mapper, IDbContextFactory<TestDbContext> contextFactory)
        : base(mapper, contextFactory)
    {
    }
}
