using Microsoft.EntityFrameworkCore;

namespace Prodot.Patterns.Cqrs.EfCore.Tests.StrongIdTests;

public class StrongIdCountQueryHandlerTests : EfCoreTestBase
{
    [Fact]
    public async Task RunQueryAsync_ReturnsCorrectCount()
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

        var entities = await Context.Set<TestEntityStrongId>().CountAsync();

        var query = new TestModelStrongIdCountQuery();
        var subjectUnderTest = new TestModelStrongIdCountQueryHandler(ContextFactory);

        // Act
        var result = await subjectUnderTest.RunQueryAsync(query, default);

        // Assert
        result.IsSome.Should().BeTrue("because the query should be successful");
        result.Get().Should().Be(3);
    }
}
