using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ExpenseTrackerAPI.Controllers.CategoriesController;
using ExpensesTrackerAPI.Contexts;
using ExpensesTrackerAPI.Models;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ExpensesTrackerContext _context;

        public CategoriesController(ExpensesTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Categories?UserIdTemp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories(string UserIdTemp)
        {
            var categories = await _context.Categories
            .FromSqlInterpolated($"SELECT * FROM Categories WHERE user_id_temp = {UserIdTemp} OR user_id_temp = 'DEFAULT'")
            .ToListAsync();

            if (categories == null)
                return NotFound();

            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        public class UpdateCategoryDto
        {
            public string? Name { get; set; }
            public int MaxBudget { get; set; }
            public string? Color { get; set; }
            public string? Emoji { get; set; }
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> PutCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            var categoryToUpdate = await _context.Categories.FindAsync(id);
            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            categoryToUpdate.Name = updateCategoryDto.Name;
            categoryToUpdate.MaxBudget = updateCategoryDto.MaxBudget;
            categoryToUpdate.Color = updateCategoryDto.Color;
            categoryToUpdate.Emoji = updateCategoryDto.Emoji;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(categoryToUpdate);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            category.Id = 0;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}