namespace TrickingLibrary.Models
{
    public class TrickCategory
    {
        public Trick Trick { get; set; }
        public string TrickId { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}