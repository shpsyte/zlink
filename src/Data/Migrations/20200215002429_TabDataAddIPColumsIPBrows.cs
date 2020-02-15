using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TabDataAddIPColumsIPBrows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Iso",
                table: "TagData",
                newName: "CountryCode");

            migrationBuilder.AddColumn<string>(
                name: "IpFromServer",
                table: "TagData",
                type: "varchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpFromServer",
                table: "TagData");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "TagData",
                newName: "Iso");
        }
    }
}
