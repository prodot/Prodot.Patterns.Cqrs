namespace Prodot.Patterns.Cqrs.EfCore.Tests.StrongIdTests;

public class StrongIdSingleModelQueryHandlerTests : EfCoreTestBase
{
    [Fact]
    public async Task RunQueryAsync_RetrievesEntityCorrectly()
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

        var query = new TestModelStrongIdQuery
        {
            Id = TestModelStrongId.Identifier.From(entity2.Id.Value)
        };
        var subjectUnderTest = new TestModelStrongIdQueryHandler(Mapper, ContextFactory);

        // Act
        var result = await subjectUnderTest.RunQueryAsync(query, default);

        // Assert
        result.IsSome.Should().BeTrue("because the retrieval should be successful");
        result.Get().Id.Should().Be(TestModelStrongId.Identifier.From(entity2.Id.Value));
        result.Get().StringProperty.Should().Be("Bla2");
    }
}
