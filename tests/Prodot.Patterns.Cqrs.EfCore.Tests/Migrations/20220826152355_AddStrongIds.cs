using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prodot.Patterns.Cqrs.EfCore.Tests.Migrations
{
    /// <inheritdoc />
    public partial class AddStrongIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StrongIdEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    StringProperty = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrongIdEntities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrongIdEntities");
        }
    }
}
