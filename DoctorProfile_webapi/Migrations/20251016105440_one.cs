using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalAppointment.Migrations
{
    /// <inheritdoc />
    public partial class one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Doctors_DoctorId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Location_LocationId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Patient_PatientId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_PatientId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Availability_DoctorId",
                table: "Availability");

            migrationBuilder.DropIndex(
                name: "IX_Availability_LocationId",
                table: "Availability");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Patient",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patient",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Patient",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MedicalHist",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfVisit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHist", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_MedicalHist_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalHist_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHist_DoctorId",
                table: "MedicalHist",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHist_PatientId",
                table: "MedicalHist",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalHist");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Patient");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_PatientId",
                table: "Ratings",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_DoctorId",
                table: "Availability",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_LocationId",
                table: "Availability",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Doctors_DoctorId",
                table: "Availability",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "doctor_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Location_LocationId",
                table: "Availability",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Patient_PatientId",
                table: "Ratings",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
