using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesTrackerAPI.Models
{
    [Keyless]
    public class SpendingAmountDto
    {
        public int id { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal spending_amount { get; set; }
    }
}
