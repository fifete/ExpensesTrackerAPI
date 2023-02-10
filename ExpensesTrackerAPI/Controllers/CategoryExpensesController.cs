using ExpensesTrackerAPI.Contexts;
using ExpensesTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpensesTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryExpensesController : ControllerBase
    {
        private readonly ExpensesTrackerContext _context;

        public CategoryExpensesController(ExpensesTrackerContext context)
        {
            _context = context;
        }

        [HttpGet("{uidTemp}")]
        public async Task<ActionResult<CategoryExpensesAmount>> GetCategoriesExpensesAmount(string date, string uidTemp)
        {
            var categoriesExpensesAmount = await _context.CategoriesExpenses
            .FromSqlInterpolated($"SELECT * FROM category_expenses WHERE date = {date} AND user_id_temp = {uidTemp}")
            .ToListAsync();

            if (categoriesExpensesAmount == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(categoriesExpensesAmount);
            }
        }

        [HttpGet("{uidTemp}/{categoryId}")]
        public async Task<ActionResult<SpendingAmountDto>> GetCategoryExpenses(int categoryId, string uidTemp)
        {
            var categoryExpense = await _context.SpendingsAmount
            .FromSqlInterpolated($"SELECT * FROM spending_amount WHERE id = {categoryId} AND user_id_temp = {uidTemp}")
            .FirstOrDefaultAsync();

            if (categoryExpense == null)
            {
                return Ok(new SpendingAmountDto { spending_amount = 0 });
            }
            else
            {
                return Ok(categoryExpense);
            }
        }
    }
}