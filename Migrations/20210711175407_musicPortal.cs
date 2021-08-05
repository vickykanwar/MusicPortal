using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPortal.Migrations
{
    public partial class musicPortal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authenticatio",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UName = table.Column<string>(nullable: true),
                    UPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authenticatio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Singer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UName = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mtitle = table.Column<string>(nullable: true),
                    MName = table.Column<string>(nullable: true),
                    Mdate = table.Column<DateTime>(nullable: false),
                    MLink = table.Column<string>(nullable: true),
                    singerid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.id);
                    table.ForeignKey(
                        name: "FK_Music_Singer_singerid",
                        column: x => x.singerid,
                        principalTable: "Singer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mtitle = table.Column<string>(nullable: true),
                    MName = table.Column<string>(nullable: true),
                    Mdate = table.Column<DateTime>(nullable: false),
                    VLink = table.Column<string>(nullable: true),
                    singerid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.id);
                    table.ForeignKey(
                        name: "FK_Video_Singer_singerid",
                        column: x => x.singerid,
                        principalTable: "Singer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Music_singerid",
                table: "Music",
                column: "singerid");

            migrationBuilder.CreateIndex(
                name: "IX_Video_singerid",
                table: "Video",
                column: "singerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authenticatio");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Singer");
        }
    }
}
