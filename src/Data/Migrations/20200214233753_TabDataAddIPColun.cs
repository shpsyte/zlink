using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TabDataAddIPColun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryFlag",
                table: "TagData",
                type: "varchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "TagData",
                type: "varchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryFlag",
                table: "TagData");

            migrationBuilder.DropColumn(
                name: "Ip",
                table: "TagData");
        }
    }
}
