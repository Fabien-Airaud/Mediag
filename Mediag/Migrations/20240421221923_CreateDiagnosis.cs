using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mediag.Migrations
{
    /// <inheritdoc />
    public partial class CreateDiagnosis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<bool>(type: "bit", nullable: false),
                    MedicalFileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosis_MedicalFiles_MedicalFileId",
                        column: x => x.MedicalFileId,
                        principalTable: "MedicalFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_MedicalFileId",
                table: "Diagnosis",
                column: "MedicalFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosis");
        }
    }
}
