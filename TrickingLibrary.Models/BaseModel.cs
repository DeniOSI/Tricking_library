namespace TrickingLibrary.Models
{
    public abstract class BaseModel
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
    }
}