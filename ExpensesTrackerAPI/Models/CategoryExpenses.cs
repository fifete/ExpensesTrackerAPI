using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesTrackerAPI.Models
{
    [Keyless]
    public class CategoryExpenseDto
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal SpendingAmount { get; set; }
    }
}
