using ExpensesTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Contexts
{
    public class ExpensesTrackerContext : DbContext
    {
        public ExpensesTrackerContext(DbContextOptions<ExpensesTrackerContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("users");
                user.HasKey(u => u.Id);
                user.Property(u => u.Id).HasColumnName("id").ValueGeneratedOnAdd();
                user.Property(u => u.Email).HasColumnName("email").HasColumnType("varchar(100)").IsRequired();
                user.Property(u => u.Password).HasColumnName("password").HasColumnType("varchar(50)").IsRequired();
                user.Property(u => u.Username).HasColumnName("username").HasColumnType("varchar(20)").IsRequired();
            });
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("categories");
                category.HasKey(c => c.Id);
                category.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
                category.Property(c => c.UserId).HasColumnName("user_id");
                category.Property(c => c.UserIdTemp).HasColumnName("user_id_temp").HasColumnType("varchar(150)").IsRequired();
                category.Property(c => c.MaxBudget).HasColumnName("max_budget").IsRequired();
                category.Property(c => c.SpendingAmount).HasColumnName("spending_amount").IsRequired();
                category.Property(c => c.Name).HasColumnName("name").HasColumnType("varchar(30)").IsRequired();
                category.Property(c => c.Color).HasColumnName("color").HasColumnType("varchar").IsRequired();
                category.Property(c => c.Emoji).HasColumnName("emoji").HasColumnType("varchar").IsRequired();

                category.HasOne(c => c.User)
                   .WithMany(u => u.Categories)
                   .HasForeignKey(c => c.UserId)
                   .HasConstraintName("user_id_fkey");
            });
            modelBuilder.Entity<Expense>(expense =>
            {
                expense.ToTable("expenses");
                expense.HasKey(e => e.Id);
                expense.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
                expense.Property(e => e.CategoryId).HasColumnName("category_id");
                expense.Property(e => e.UserId).HasColumnName("user_id");
                expense.Property(e => e.UserIdTemp).HasColumnName("user_id_temp");

                expense.Property(e => e.Amount).HasColumnName("amount").IsRequired();
                expense.Property(e => e.Date).HasColumnName("date").HasColumnType("varchar(100)").IsRequired();
                expense.Property(e => e.Time).HasColumnName("time").HasColumnType("varchar(100)").IsRequired();
                expense.Property(e => e.Description).HasColumnName("description").HasColumnType("varchar(30)").IsRequired();
                expense.HasOne(e => e.Category)
                    .WithMany(c => c.Expenses)
                    .HasForeignKey(e => e.CategoryId)
                    .HasConstraintName("category_id_fkey");
            });
            modelBuilder.Entity<CategoryExpenseDto>(catexp =>
            {
                catexp.ToTable("categories_expenses");
                catexp.Property(e => e.Id).HasColumnName("id");
            });
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Expense> Expenses { get; set; } = null!;
        public DbSet<CategoryExpenseDto> CategoriesExpenses { get; set; } = null!;
        public DbSet<ExpenseByDate> ExpensesByDate { get; set; }

    }
}
