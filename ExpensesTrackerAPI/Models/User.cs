using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }

        public ICollection<Category>? Categories { get; set; }
    }
}
