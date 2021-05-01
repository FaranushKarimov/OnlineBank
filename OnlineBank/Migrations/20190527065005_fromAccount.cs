using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBank.Migrations
{
    public partial class fromAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "fromAccount",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "toAccount",
                table: "Transactions",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "fromAccount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "toAccount",
                table: "Transactions");
        }
    }
}
