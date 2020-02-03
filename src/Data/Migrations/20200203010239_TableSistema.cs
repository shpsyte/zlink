using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TableSistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    TargetLink = table.Column<string>(type: "varchar(100)", nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Thumb = table.Column<byte[]>(nullable: true),
                    HideInfo = table.Column<string>(type: "varchar(100)", nullable: true),
                    ShortText = table.Column<string>(type: "varchar(100)", nullable: true),
                    OpenNewTab = table.Column<bool>(nullable: false),
                    Campaingn = table.Column<string>(type: "varchar(100)", nullable: true),
                    Parameters = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsPriority = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Continent = table.Column<string>(type: "varchar(100)", nullable: true),
                    ContinentCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    Country = table.Column<string>(type: "varchar(100)", nullable: true),
                    Region = table.Column<string>(type: "varchar(100)", nullable: true),
                    RegionName = table.Column<string>(type: "varchar(100)", nullable: true),
                    City = table.Column<string>(type: "varchar(100)", nullable: true),
                    District = table.Column<string>(type: "varchar(100)", nullable: true),
                    Lat = table.Column<string>(type: "varchar(100)", nullable: true),
                    Lon = table.Column<string>(type: "varchar(100)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    TimeZone = table.Column<string>(type: "varchar(100)", nullable: true),
                    Currency = table.Column<string>(type: "varchar(100)", nullable: true),
                    Iso = table.Column<string>(type: "varchar(100)", nullable: true),
                    Organization = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsMobile = table.Column<bool>(nullable: false),
                    WebBrowserClient = table.Column<string>(type: "varchar(100)", nullable: true),
                    SoClient = table.Column<string>(type: "varchar(100)", nullable: true),
                    ISP = table.Column<string>(type: "varchar(100)", nullable: true)
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
