using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetTest.Migrations
{
    public partial class AddedCommponentState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "componentState",
                table: "componentCollection",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "componentState",
                table: "componentCollection");
        }
    }
}
