namespace Prodot.Patterns.Cqrs.EfCore.Tests.StrongIdTests;

public class StrongIdCreateQueryHandlerTests : EfCoreTestBase
{
    [Fact]
    public async Task RunQueryAsync_CreatesModelSuccessfully()
    {
        // Arrange
        var model = new TestModelStrongId
        {
            Id = TestModelStrongId.Identifier.From(0),
            StringProperty = "Bla"
        };
        var query = new TestModelStrongIdCreateQuery
        {
            ModelToCreate = model,
        };
        var subjectUnderTest = new TestModelStrongIdCreateQueryHandler(Mapper, ContextFactory);

        // Act
        var result = await subjectUnderTest.RunQueryAsync(query, default);

        // Assert
        result.IsSome.Should().BeTrue("because the creation should be successful");
        var entities = Context.StrongIdEntities.ToList();
        entities.Should().HaveCount(1);
        entities[0].StringProperty.Should().Be("Bla");
    }
}
