using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesTrackerAPI.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }

        public Category? Category { get; set; }
    }
}
