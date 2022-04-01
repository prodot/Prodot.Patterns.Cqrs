using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Context;
using Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Queries;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelQueryHandler : SingleModelQueryHandlerBase<TestModelQuery, TestModel, TestModelId, int, TestDbContext, TestEntity>
{
    public TestModelQueryHandler(IMapper mapper, IDbContextFactory<TestDbContext> contextFactory)
        : base(mapper, contextFactory)
    {
    }
}
