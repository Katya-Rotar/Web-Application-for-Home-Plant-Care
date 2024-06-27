using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomePlantCareApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPlantDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlantDescription",
                table: "PlantTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlantDescription",
                table: "PlantTypes");
        }
    }
}
