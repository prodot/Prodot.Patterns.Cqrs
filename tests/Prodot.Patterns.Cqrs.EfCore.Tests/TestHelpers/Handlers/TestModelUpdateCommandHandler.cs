using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelUpdateCommandHandler
    : UpdateCommandHandlerBase<TestModelUpdateCommand, TestModel, TestModelId, int, TestDbContext, TestEntity, int>
{
    public TestModelUpdateCommandHandler(IMapper mapper, IDbContextFactory<TestDbContext> contextFactory)
        : base(mapper, contextFactory)
    {
    }
}
