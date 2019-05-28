using Microsoft.EntityFrameworkCore.Migrations;

namespace rabotyagiszavoda.Migrations
{
    public partial class IQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IQ",
                table: "workers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IQ",
                table: "workers");
        }
    }
}
