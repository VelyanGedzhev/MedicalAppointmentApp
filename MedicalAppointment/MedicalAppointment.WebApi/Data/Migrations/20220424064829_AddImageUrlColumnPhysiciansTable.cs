using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalAppointment.WebApi.Data.Migrations
{
    public partial class AddImageUrlColumnPhysiciansTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Physicians",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Physicians");
        }
    }
}
