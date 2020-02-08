using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false),
                    TargetLink = table.Column<string>(type: "varchar(max)", nullable: false),
                    Start = table.Column<DateTime>(nullable: true),
                    End = table.Column<DateTime>(nullable: true),
                    Thumb = table.Column<byte[]>(nullable: true),
                    HideInfo = table.Column<string>(type: "varchar(max)", nullable: true),
                    ShortText = table.Column<string>(type: "varchar(max)", nullable: true),
                    OpenNewTab = table.Column<bool>(nullable: false, defaultValue: false),
                    Campaing = table.Column<string>(type: "varchar(max)", nullable: true),
                    Parameters = table.Column<string>(type: "varchar(max)", nullable: true),
                    IsPriority = table.Column<bool>(nullable: false, defaultValue: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Continent = table.Column<string>(type: "varchar(max)", nullable: true),
                    ContinentCode = table.Column<string>(type: "varchar(max)", nullable: true),
                    Country = table.Column<string>(type: "varchar(max)", nullable: true),
                    Region = table.Column<string>(type: "varchar(max)", nullable: true),
                    RegionName = table.Column<string>(type: "varchar(max)", nullable: true),
                    City = table.Column<string>(type: "varchar(max)", nullable: true),
                    District = table.Column<string>(type: "varchar(max)", nullable: true),
                    Lat = table.Column<string>(type: "varchar(max)", nullable: true),
                    Lon = table.Column<string>(type: "varchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(max)", nullable: true),
                    TimeZone = table.Column<string>(type: "varchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "varchar(max)", nullable: true),
                    Iso = table.Column<string>(type: "varchar(max)", nullable: true),
                    Organization = table.Column<string>(type: "varchar(max)", nullable: true),
                    IsMobile = table.Column<bool>(nullable: false, defaultValue: false),
                    WebBrowserClient = table.Column<string>(type: "varchar(max)", nullable: true),
                    SoClient = table.Column<string>(type: "varchar(max)", nullable: true),
                    ISP = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagData_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagData_TagId",
                table: "TagData",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagData");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
