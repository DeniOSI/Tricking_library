namespace TrickingLibrary.Models
{
    public class TrickRelationship
    {
        public string ProgressionId { get; set; }
        public Trick Progression { get; set; }
        public string PrerequisitesId { get; set; }
        public Trick Prerequisites { get; set; }
    }
}