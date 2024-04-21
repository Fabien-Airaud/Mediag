using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mediag.Migrations
{
    /// <inheritdoc />
    public partial class CreateChestPainTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IllnessTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ChestPainTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChestPainTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ChestPainTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Typical angina" },
                    { 2L, "Atypical angina" },
                    { 3L, "Non anginal pain" },
                    { 4L, "Asymptomatic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IllnessTypes_Name",
                table: "IllnessTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChestPainTypes_Name",
                table: "ChestPainTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChestPainTypes");

            migrationBuilder.DropIndex(
                name: "IX_IllnessTypes_Name",
                table: "IllnessTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IllnessTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
