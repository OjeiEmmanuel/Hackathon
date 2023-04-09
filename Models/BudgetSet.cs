namespace Hackathon.Models
{
    public class BudgetSet
    {public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
         public DateTime? CreatedDate { get; set; }=DateTime.Now;
        public DateTime? LastDate { get; set; }
    }
}
