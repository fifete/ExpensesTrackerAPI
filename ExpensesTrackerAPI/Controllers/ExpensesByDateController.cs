using ExpensesTrackerAPI.Contexts;
using ExpensesTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesByDate : ControllerBase
    {
        private readonly ExpensesTrackerContext _context;

        public ExpensesByDate(ExpensesTrackerContext context)
        {
            _context = context;
        }

        // GET: api/ExpensesByDate/
        [HttpGet]
        public async Task<ActionResult<ExpenseByDate>> GetExpensesByUsernameAndDate(string UserIdTemp, string date)
        {
            var expensesByDate = await _context.ExpensesByDate
                .FromSqlInterpolated($"SELECT * FROM expenses_by_date WHERE user_id_temp = {UserIdTemp} AND date = {date}")
                .FirstOrDefaultAsync();

            if (expensesByDate == null)
            {
                return Ok(new ExpenseByDate { total_amount = 0 });
            }
            else
            {
                return Ok(expensesByDate);
            }
        }
    }
}
