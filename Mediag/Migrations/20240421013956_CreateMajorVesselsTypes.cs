using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mediag.Migrations
{
    /// <inheritdoc />
    public partial class CreateMajorVesselsTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MajorVesselsTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MajorVesselsTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MajorVesselsTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Zero" },
                    { 2L, "One" },
                    { 3L, "Two" },
                    { 4L, "Three" },
                    { 5L, "Four" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MajorVesselsTypes_Name",
                table: "MajorVesselsTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MajorVesselsTypes");
        }
    }
}
