using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationToAppTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Tasks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Tasks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Tasks");
        }
    }
}
