using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Models
{
    [Keyless]
    public class ExpenseByDate
    {
        public string? user_id_temp { get; set; }
        public string? date { get; set; }
        public decimal total_amount { get; set; }
    }
}
