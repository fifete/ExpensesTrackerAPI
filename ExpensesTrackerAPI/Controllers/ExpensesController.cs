using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpensesTrackerAPI.Contexts;
using ExpensesTrackerAPI.Models;

namespace ExpenseTrackerAPI.Controllers
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

        // GET: api/Expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses(int categoryId, string userIdTemp)
        {
            var expenses = _context.Expenses.AsQueryable();

            if (!string.IsNullOrEmpty(categoryId.ToString()) && !string.IsNullOrEmpty(userIdTemp))
            {
                expenses = expenses.Where(e => e.CategoryId == categoryId && e.UserIdTemp == userIdTemp);
            }
            return await expenses.ToListAsync();
        }


        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }


        public class UpdateExpenseDto
        {
            public decimal Amount { get; set; }
            public string? Description { get; set; }
            public string? Date { get; set; }
            public string? Time { get; set; }
        }
        // PUT: api/Expenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, UpdateExpenseDto updateExpenseDto)
        {
            var expenseToUpdate = await _context.Expenses.FindAsync(id);
            if (expenseToUpdate == null)
            {
                return NotFound();
            }

            expenseToUpdate.Amount = updateExpenseDto.Amount;
            expenseToUpdate.Description = updateExpenseDto.Description;
            expenseToUpdate.Date = updateExpenseDto.Date;
            expenseToUpdate.Time = updateExpenseDto.Time;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(expenseToUpdate);
        }

        // POST: api/Expenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(Expense expense)
        {
            // db create the id
            expense.Id = 0;
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, expense);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}