using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTrackerAPI.Migrations
{
    public partial class Update_spendingAmountView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW spending_amount AS
            SELECT c.id, e.user_id_temp, SUM(e.amount) as spending_amount
            FROM categories c
            LEFT JOIN expenses e ON c.id = e.category_id
            GROUP BY c.id, e.user_id_temp;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
