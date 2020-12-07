using Microsoft.EntityFrameworkCore.Migrations;

namespace Julius.Data.Migrations
{
    public partial class nova_coluna_bilingDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillingDate",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingDate",
                table: "Expense");
        }
    }
}
