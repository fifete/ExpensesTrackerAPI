using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Models
{
    [Keyless]
    public class CategoryExpensesAmount
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? date { get; set; }
        public string? color { get; set; }
        public decimal spending_amount { get; set; }
        public string? user_id_temp { get; set; }
    }
}
