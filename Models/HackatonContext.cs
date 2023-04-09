using Microsoft.EntityFrameworkCore;

namespace Hackathon.Models
{
    public class HackatonContext : DbContext
    { public HackatonContext(DbContextOptions<HackatonContext> options) : base(options)
        { 
        }
        public DbSet <BudgetItem> BudgetItems { get; set; }
        public DbSet <BudgetSet> BudgetSets { get; set; }
        public DbSet <Income> Incomes { get; set; }
        public DbSet <Transaction> Transactions { get; set; }
        public DbSet <UserId> Users { get; set; }
    }
}
