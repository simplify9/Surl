using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SW.Surl.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "surl");

            migrationBuilder.CreateTable(
                name: "short_url",
                schema: "surl",
                columns: table => new
                {
                    id = table.Column<string>(type: "character(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    full_url = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_short_url", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "short_url",
                schema: "surl");
        }
    }
}
