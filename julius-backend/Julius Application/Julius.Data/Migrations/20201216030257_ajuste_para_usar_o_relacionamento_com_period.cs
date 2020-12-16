using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Julius.Data.Migrations
{
    public partial class ajuste_para_usar_o_relacionamento_com_period : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Expense");

            migrationBuilder.AddColumn<Guid>(
                name: "PeriodId",
                table: "Income",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("C1247792-BCC2-40E3-9879-13C366F8A30F"));

            migrationBuilder.AddColumn<Guid>(
                name: "PeriodId",
                table: "Expense",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("C1247792-BCC2-40E3-9879-13C366F8A30F"));

            migrationBuilder.CreateIndex(
                name: "IX_Income_PeriodId",
                table: "Income",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_PeriodId",
                table: "Expense",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Period_PeriodId",
                table: "Expense",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Period_PeriodId",
                table: "Income",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Period_PeriodId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_Period_PeriodId",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Income_PeriodId",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Expense_PeriodId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Expense");

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Income",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Income",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
