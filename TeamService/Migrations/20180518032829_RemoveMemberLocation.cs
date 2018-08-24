using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TeamService.Migrations
{
    public partial class RemoveMemberLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationRecord");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationRecord",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    MemberID = table.Column<Guid>(nullable: false),
                    TimeStamp = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationRecord", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LocationRecord_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationRecord_MemberID",
                table: "LocationRecord",
                column: "MemberID",
                unique: true);
        }
    }
}
