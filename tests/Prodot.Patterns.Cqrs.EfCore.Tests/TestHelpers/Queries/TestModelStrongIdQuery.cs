namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Queries;

public class TestModelStrongIdQuery
    : SingleModelQuery<TestModelStrongId, TestModelStrongId.Identifier, int, TestModelStrongIdQuery>
{
}
