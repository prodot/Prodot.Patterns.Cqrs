using StronglyTypedIds;

using static Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Context.TestEntityStrongId;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.TestHelpers.Context;

public partial class TestEntityStrongId : IIdentifiableEntity<Identifier>
{
    public Identifier Id { get; set; }

    public string StringProperty { get; set; } = string.Empty;

    [StronglyTypedId(StronglyTypedIdBackingType.Int, StronglyTypedIdConverter.EfCoreValueConverter)]
    public partial struct Identifier
    {
    }
}
