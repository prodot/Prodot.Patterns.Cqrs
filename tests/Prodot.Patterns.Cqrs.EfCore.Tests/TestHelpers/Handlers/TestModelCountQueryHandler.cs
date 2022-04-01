﻿using Microsoft.EntityFrameworkCore;

using Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Context;
using Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Queries;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Handlers;

public class TestModelCountQueryHandler : CountQueryHandlerBase<TestModelCountQuery, TestModel, TestModelId, int, TestDbContext, TestEntity>
{
    public TestModelCountQueryHandler(IDbContextFactory<TestDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}
