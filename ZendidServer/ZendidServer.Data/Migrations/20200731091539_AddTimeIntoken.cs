using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZendidServer.Data.Migrations
{
    public partial class AddTimeIntoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfLastUpdate",
                table: "Tokens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeOfLastUpdate",
                table: "Tokens");
        }
    }
}
