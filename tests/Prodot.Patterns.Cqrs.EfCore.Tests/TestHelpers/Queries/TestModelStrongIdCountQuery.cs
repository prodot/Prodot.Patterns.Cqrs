namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Queries;

public class TestModelStrongIdCountQuery
    : CountQuery<TestModelStrongId, TestModelStrongId.Identifier, int, TestModelStrongIdCountQuery>
{
}
