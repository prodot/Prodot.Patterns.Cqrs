using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelStrongIdUpdateCommandHandler
    : UpdateCommandHandlerBase<TestModelStrongIdUpdateCommand, TestModelStrongId, TestModelStrongId.Identifier, int, TestDbContext, TestEntityStrongId, TestEntityStrongId.Identifier>
{
    public TestModelStrongIdUpdateCommandHandler(IMapper mapper, IDbContextFactory<TestDbContext> contextFactory)
        : base(mapper, contextFactory)
    {
    }
}
