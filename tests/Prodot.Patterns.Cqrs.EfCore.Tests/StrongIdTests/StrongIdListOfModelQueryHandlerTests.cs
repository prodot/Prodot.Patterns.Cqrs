namespace Prodot.Patterns.Cqrs.EfCore.Tests.StrongIdTests;

public class StrongIdListOfModelQueryHandlerTests : EfCoreTestBase
{
    [Fact]
    public async Task RunQueryAsync_RetrievesAllEntitiesCorrectly()
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

        var query = new TestModelsStrongIdQuery
        {
            Ids = Option.None
        };
        var subjectUnderTest = new TestModelsStrongIdQueryHandler(Mapper, ContextFactory);

        // Act
        var result = await subjectUnderTest.RunQueryAsync(query, default);

        // Assert
        result.IsSome.Should().BeTrue("because the retrieval should be successful");
        result.Get().Should().HaveCount(3);
    }

    [Fact]
    public async Task RunQueryAsync_RetrievesSelectedEntitiesCorrectly()
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

        var query = new TestModelsStrongIdQuery
        {
            Ids = new List<TestModelStrongId.Identifier>
            {
                TestModelStrongId.Identifier.From(entity2.Id.Value),
                TestModelStrongId.Identifier.From(entity3.Id.Value)
            }
        };
        var subjectUnderTest = new TestModelsStrongIdQueryHandler(Mapper, ContextFactory);

        // Act
        var result = await subjectUnderTest.RunQueryAsync(query, default);

        // Assert
        result.IsSome.Should().BeTrue("because the retrieval should be successful");
        result.Get().Should().HaveCount(2);

        result.Get().First().Id.Should().Be(TestModelStrongId.Identifier.From(entity2.Id.Value));
        result.Get().First().StringProperty.Should().Be("Bla2");

        result.Get().Last().Id.Should().Be(TestModelStrongId.Identifier.From(entity3.Id.Value));
        result.Get().Last().StringProperty.Should().Be("Bla3");
    }
}
