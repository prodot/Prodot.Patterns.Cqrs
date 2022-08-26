namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Queries;

public class TestModelStrongIdDeleteCommand
    : DeleteCommand<TestModelStrongId, TestModelStrongId.Identifier, int, TestModelStrongIdDeleteCommand>
{
}
