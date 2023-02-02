using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTrackerAPI.Migrations
{
    public partial class NewChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ExpensesByDate",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "UserIdTemp",
                table: "ExpensesByDate",
                newName: "user_id_temp");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "ExpensesByDate",
                newName: "total_amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "ExpensesByDate",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "user_id_temp",
                table: "ExpensesByDate",
                newName: "UserIdTemp");

            migrationBuilder.RenameColumn(
                name: "total_amount",
                table: "ExpensesByDate",
                newName: "TotalAmount");
        }
    }
}
