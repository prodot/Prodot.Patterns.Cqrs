using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelStrongIdDeleteCommandHandler
    : DeleteCommandHandlerBase<TestModelStrongIdDeleteCommand, TestModelStrongId, TestModelStrongId.Identifier, int, TestDbContext, TestEntityStrongId, TestEntityStrongId.Identifier>
{
    public TestModelStrongIdDeleteCommandHandler(IMapper mapper, IDbContextFactory<TestDbContext> contextFactory)
        : base(mapper, contextFactory)
    {
    }
}
