namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Queries;

public class TestModelStrongIdUpdateCommand
    : UpdateCommand<TestModelStrongId, TestModelStrongId.Identifier, int, TestModelStrongIdUpdateCommand>
{
}
