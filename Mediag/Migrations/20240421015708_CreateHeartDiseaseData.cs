using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mediag.Migrations
{
    /// <inheritdoc />
    public partial class CreateHeartDiseaseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeartDiseaseDatas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChestPainId = table.Column<long>(type: "bigint", nullable: false),
                    ThalassemiaId = table.Column<long>(type: "bigint", nullable: false),
                    MajorVesselsId = table.Column<long>(type: "bigint", nullable: false),
                    OldPeak = table.Column<double>(type: "float", nullable: false),
                    MaximumHeartRateAchieved = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<bool>(type: "bit", nullable: false),
                    MedicalFileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeartDiseaseDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeartDiseaseDatas_ChestPainTypes_ChestPainId",
                        column: x => x.ChestPainId,
                        principalTable: "ChestPainTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeartDiseaseDatas_MajorVesselsTypes_MajorVesselsId",
                        column: x => x.MajorVesselsId,
                        principalTable: "MajorVesselsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeartDiseaseDatas_MedicalFiles_MedicalFileId",
                        column: x => x.MedicalFileId,
                        principalTable: "MedicalFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeartDiseaseDatas_ThalassemiaTypes_ThalassemiaId",
                        column: x => x.ThalassemiaId,
                        principalTable: "ThalassemiaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeartDiseaseDatas_ChestPainId",
                table: "HeartDiseaseDatas",
                column: "ChestPainId");

            migrationBuilder.CreateIndex(
                name: "IX_HeartDiseaseDatas_MajorVesselsId",
                table: "HeartDiseaseDatas",
                column: "MajorVesselsId");

            migrationBuilder.CreateIndex(
                name: "IX_HeartDiseaseDatas_MedicalFileId",
                table: "HeartDiseaseDatas",
                column: "MedicalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_HeartDiseaseDatas_ThalassemiaId",
                table: "HeartDiseaseDatas",
                column: "ThalassemiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeartDiseaseDatas");
        }
    }
}
