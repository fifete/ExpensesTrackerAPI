using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTrackerAPI.Migrations
{
    public partial class Update_CategoryExpensesView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories_expenses");

            migrationBuilder.CreateTable(
                name: "CategoriesExpenses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<string>(type: "text", nullable: true),
                    spending_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    user_id_temp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.Sql(@"CREATE VIEW category_expenses AS
            SELECT c.id, c.name, c.color, e.user_id_temp, e.date, SUM(e.amount) as spending_amount
            FROM categories c
            LEFT JOIN expenses e ON c.id = e.category_id
            GROUP BY c.id, e.user_id_temp, e.date, c.name, c.color;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesExpenses");

            migrationBuilder.CreateTable(
                name: "categories_expenses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    spendingamount = table.Column<decimal>(type: "numeric(8,2)", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
