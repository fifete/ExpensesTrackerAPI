using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTrackerAPI.Migrations
{
    public partial class Add_SpendingsAmount_view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "CategoriesExpenses",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpendingsAmount",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    spending_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.Sql(@"CREATE VIEW spending_amount AS
            SELECT c.id, e.user_id_temp, SUM(e.amount) as SpendingAmount
            FROM categories c
            LEFT JOIN expenses e ON c.id = e.category_id
            GROUP BY c.id, e.user_id_temp;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpendingsAmount");

            migrationBuilder.DropColumn(
                name: "color",
                table: "CategoriesExpenses");
        }
    }
}
