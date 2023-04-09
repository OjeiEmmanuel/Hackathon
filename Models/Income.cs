namespace Hackathon.Models
{
    public class Income
    { public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? Narration { get; set; }
        public string? Category { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;

    }
}
