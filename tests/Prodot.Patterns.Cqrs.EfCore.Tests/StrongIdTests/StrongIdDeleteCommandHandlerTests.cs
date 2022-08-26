namespace Prodot.Patterns.Cqrs.EfCore.Tests.StrongIdTests;

public class StrongIdDeleteCommandHandlerTests : EfCoreTestBase
{
    [Fact]
    public async Task RunQueryAsync_DeletesEntityCorrectly()
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

        var query = new TestModelStrongIdDeleteCommand
        {
            Id = TestModelStrongId.Identifier.From(entity2.Id.Value)
        };
        var subjectUnderTest = new TestModelStrongIdDeleteCommandHandler(Mapper, ContextFactory);

        // Act
        var result = await subjectUnderTest.RunQueryAsync(query, default);

        // Assert
        result.IsSome.Should().BeTrue("because the deletion should be successful");
        var entityCount = Context.StrongIdEntities.Count();
        entityCount.Should().Be(2);
    }
}
