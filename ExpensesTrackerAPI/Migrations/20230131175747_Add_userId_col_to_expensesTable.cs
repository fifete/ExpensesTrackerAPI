using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTrackerAPI.Migrations
{
    public partial class Add_userId_col_to_expensesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpendingAmount",
                table: "categories_expenses",
                newName: "spendingamount");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "expenses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_id_temp",
                table: "expenses",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "user_id_temp",
                table: "expenses");

            migrationBuilder.RenameColumn(
                name: "spendingamount",
                table: "categories_expenses",
                newName: "SpendingAmount");
        }
    }
}
