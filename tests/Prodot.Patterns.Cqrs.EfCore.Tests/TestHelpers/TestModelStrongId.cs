using static Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.TestModelStrongId;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers;

public class TestModelStrongId : TestModelBase<Identifier>
{
    public string StringProperty { get; set; } = string.Empty;

    public record Identifier : Identifier<int, Identifier>
    {
    }
}
