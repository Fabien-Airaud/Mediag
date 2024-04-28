using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mediag.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IllnessTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IllnessTypes", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialism = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalId = table.Column<long>(type: "bigint", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<long>(type: "bigint", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    TargetIllnessId = table.Column<long>(type: "bigint", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    HospitalId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalFiles_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalFiles_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalFiles_IllnessTypes_TargetIllnessId",
                        column: x => x.TargetIllnessId,
                        principalTable: "IllnessTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalFiles_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreastCancerDatas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadiusWorst = table.Column<double>(type: "float", nullable: false),
                    AreaWorst = table.Column<double>(type: "float", nullable: false),
                    PerimeterWorst = table.Column<double>(type: "float", nullable: false),
                    ConcavePointsWorst = table.Column<double>(type: "float", nullable: false),
                    ConcavePointsMean = table.Column<double>(type: "float", nullable: false),
                    PerimeterMean = table.Column<double>(type: "float", nullable: false),
                    Result = table.Column<bool>(type: "bit", nullable: false),
                    MedicalFileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreastCancerDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreastCancerDatas_MedicalFiles_MedicalFileId",
                        column: x => x.MedicalFileId,
                        principalTable: "MedicalFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 1L, "Montréal", "Hôpital général de Montréal" },
                    { 2L, "Greenfield Park", "Hôpital Charles-Le Moyne" },
                    { 3L, "Victoriaville", "Hôtel-Dieu d'Arthabaska" }
                });

            migrationBuilder.InsertData(
                table: "IllnessTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Breast cancer" },
                    { 2L, "Heart disease" }
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
                name: "IX_BreastCancerDatas_MedicalFileId",
                table: "BreastCancerDatas",
                column: "MedicalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_ChestPainTypes_Name",
                table: "ChestPainTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_MedicalFileId",
                table: "Diagnosis",
                column: "MedicalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalId",
                table: "Doctors",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Username",
                table: "Doctors",
                column: "Username",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_Name_City",
                table: "Hospitals",
                columns: new[] { "Name", "City" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IllnessTypes_Name",
                table: "IllnessTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MajorVesselsTypes_Name",
                table: "MajorVesselsTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFiles_DoctorId",
                table: "MedicalFiles",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFiles_HospitalId",
                table: "MedicalFiles",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFiles_PatientId",
                table: "MedicalFiles",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFiles_TargetIllnessId",
                table: "MedicalFiles",
                column: "TargetIllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalId",
                table: "Patients",
                column: "HospitalId");

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
                name: "BreastCancerDatas");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "HeartDiseaseDatas");

            migrationBuilder.DropTable(
                name: "ChestPainTypes");

            migrationBuilder.DropTable(
                name: "MajorVesselsTypes");

            migrationBuilder.DropTable(
                name: "MedicalFiles");

            migrationBuilder.DropTable(
                name: "ThalassemiaTypes");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "IllnessTypes");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
