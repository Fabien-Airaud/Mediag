using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mediag.Migrations
{
    /// <inheritdoc />
    public partial class CreateThalassemiaTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThalassemiaTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThalassemiaTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ThalassemiaTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Strange" },
                    { 2L, "Normal" },
                    { 3L, "Fixed" },
                    { 4L, "Reversable" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThalassemiaTypes_Name",
                table: "ThalassemiaTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThalassemiaTypes");
        }
    }
}
