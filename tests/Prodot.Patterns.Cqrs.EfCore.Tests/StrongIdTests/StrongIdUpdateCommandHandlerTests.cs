using Microsoft.EntityFrameworkCore;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.StrongIdTests;

public class StrongIdUpdateCommandHandlerTests : EfCoreTestBase
{
    [Fact]
    public async Task RunQueryAsync_UpdatesEntityCorrectly()
    {
        // Arrange
        var entity1 = new TestEntityStrongId
        {
            Id = TestEntityStrongId.Identifier.Empty,
            StringProperty = "Bla1"
        };
        var entity2 = new TestEntityStrongId
        {
            Id = TestEntityStrongId.Identifier.Empty,
            StringProperty = "Bla2"
        };
        var entity3 = new TestEntityStrongId
        {
            Id = TestEntityStrongId.Identifier.Empty,
            StringProperty = "Bla3"
        };

        Context.StrongIdEntities.Add(entity1);
        Context.StrongIdEntities.Add(entity2);
        Context.StrongIdEntities.Add(entity3);
        Context.SaveChanges();

        var query = new TestModelStrongIdUpdateCommand
        {
            UpdatedModel = new()
            {
                Id = TestModelStrongId.Identifier.From(entity2.Id.Value),
                StringProperty = "Foo"
            }
        };
        var subjectUnderTest = new TestModelStrongIdUpdateCommandHandler(Mapper, ContextFactory);

        // Act
        var result = await subjectUnderTest.RunQueryAsync(query, default);

        // Assert
        result.IsSome.Should().BeTrue("because the update should be successful");
        var entityCount = Context.StrongIdEntities.Count();
        entityCount.Should().Be(3);

        var updatedEntity = Context.StrongIdEntities.AsNoTracking().First(x => x.Id == entity2.Id);
        updatedEntity!.StringProperty.Should().Be("Foo");
    }
}
