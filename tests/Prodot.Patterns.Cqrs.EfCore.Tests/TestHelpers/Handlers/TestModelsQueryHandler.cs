using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Context;
using Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Queries;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelsQueryHandler : ListOfModelQueryHandlerBase<TestModelsQuery, TestModel, TestModelId, int, TestDbContext, TestEntity>
{
    public TestModelsQueryHandler(IMapper mapper, IDbContextFactory<TestDbContext> contextFactory)
        : base(mapper, contextFactory)
    {
    }
}
