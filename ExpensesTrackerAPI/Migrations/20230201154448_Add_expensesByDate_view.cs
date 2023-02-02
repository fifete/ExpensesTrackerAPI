using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTrackerAPI.Migrations
{
    public partial class Add_expensesByDate_view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW expenses_by_date AS
            SELECT date, user_id_temp,
            SUM(amount) AS total_amount
            FROM expenses
            GROUP BY date, expenses.user_id_temp;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
