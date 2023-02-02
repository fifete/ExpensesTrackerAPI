using ExpensesTrackerAPI.Contexts;
using ExpensesTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpensesTrackerContext _context;

        public ExpensesController(ExpensesTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Expenses/ByUserIdAndDate 
        [HttpGet("ByUserIdAndDate")]
        public async Task<ActionResult<ExpenseByDate>> GetExpensesByUsernameAndDate(string UserIdTemp, string date)
        {
            var expensesByDate = await _context.ExpensesByDate
                .FromSqlInterpolated($"SELECT * FROM expenses_by_date WHERE user_id_temp = {UserIdTemp} AND date = {date}")
                .FirstOrDefaultAsync();

            if (expensesByDate == null)
                return NotFound();

            return Ok(expensesByDate);
        }
    }
}
