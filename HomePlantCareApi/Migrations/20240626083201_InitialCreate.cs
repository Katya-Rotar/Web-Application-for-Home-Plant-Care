using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomePlantCareApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantTypes",
                columns: table => new
                {
                    PlantTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantTypePhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WateringFrequency = table.Column<int>(type: "int", nullable: false),
                    TransplantFrequency = table.Column<int>(type: "int", nullable: false),
                    TemperatureRequirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoilType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTypes", x => x.PlantTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantTypeID = table.Column<int>(type: "int", nullable: false),
                    PlantDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLastWatering = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastTransplant = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantID);
                    table.ForeignKey(
                        name: "FK_Plants_PlantTypes_PlantTypeID",
                        column: x => x.PlantTypeID,
                        principalTable: "PlantTypes",
                        principalColumn: "PlantTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantCares",
                columns: table => new
                {
                    CareID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    CareDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CareType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCares", x => x.CareID);
                    table.ForeignKey(
                        name: "FK_PlantCares_Plants_PlantID",
                        column: x => x.PlantID,
                        principalTable: "Plants",
                        principalColumn: "PlantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    ReminderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    ReminderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReminderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.ReminderID);
                    table.ForeignKey(
                        name: "FK_Reminders_Plants_PlantID",
                        column: x => x.PlantID,
                        principalTable: "Plants",
                        principalColumn: "PlantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantCares_PlantID",
                table: "PlantCares",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PlantTypeID",
                table: "Plants",
                column: "PlantTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_PlantID",
                table: "Reminders",
                column: "PlantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantCares");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "PlantTypes");
        }
    }
}
