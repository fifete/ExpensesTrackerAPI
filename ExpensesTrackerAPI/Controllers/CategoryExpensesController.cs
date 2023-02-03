using ExpensesTrackerAPI.Contexts;
using ExpensesTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<CategoryExpenseDto>> GetCategoryExpenses(int categoryId, string uidTemp)
        {
            var categoryExpense = await _context.CategoriesExpenses
            .FromSqlInterpolated($"SELECT * FROM category_expenses WHERE id = {categoryId} AND user_id_temp = {uidTemp}")
            .FirstOrDefaultAsync();

            if (categoryExpense == null)
            {
                return Ok(new CategoryExpenseDto { spendingamount = 0 });
            }
            else
            {
                return Ok(categoryExpense);
            }
        }

        //// POST api/<CategoryExpensesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CategoryExpensesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoryExpensesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}