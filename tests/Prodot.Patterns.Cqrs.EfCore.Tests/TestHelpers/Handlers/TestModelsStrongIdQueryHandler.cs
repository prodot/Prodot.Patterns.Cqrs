using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelsStrongIdQueryHandler : ListOfModelQueryHandlerBase<TestModelsStrongIdQuery, TestModelStrongId, TestModelStrongId.Identifier, int, TestDbContext, TestEntityStrongId, TestEntityStrongId.Identifier>
{
    public TestModelsStrongIdQueryHandler(IMapper mapper, IDbContextFactory<TestDbContext> contextFactory)
        : base(mapper, contextFactory)
    {
    }
}
