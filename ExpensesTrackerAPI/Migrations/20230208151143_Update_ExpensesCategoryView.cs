using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTrackerAPI.Migrations
{
    public partial class Update_ExpensesCategoryView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW category_expenses AS
            SELECT c.id, c.name, e.user_id_temp, e.date, SUM(e.amount) as SpendingAmount
            FROM categories c
            LEFT JOIN expenses e ON c.id = e.category_id
            GROUP BY c.id, e.user_id_temp, e.date, c.name;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
