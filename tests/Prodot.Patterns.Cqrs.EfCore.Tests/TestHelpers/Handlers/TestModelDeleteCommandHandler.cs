using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelDeleteCommandHandler
    : DeleteCommandHandlerBase<TestModelDeleteCommand, TestModel, TestModelId, int, TestDbContext, TestEntity, int>
{
    public TestModelDeleteCommandHandler(IMapper mapper, IDbContextFactory<TestDbContext> contextFactory)
        : base(mapper, contextFactory)
    {
    }
}
