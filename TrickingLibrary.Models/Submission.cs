namespace TrickingLibrary.Models
{
    public class Submission
    {
        public long Id { get; set; }
        public long TrickId { get; set; }
        public string Video { get; set; }
        public string Description { get; set; }
    }
}