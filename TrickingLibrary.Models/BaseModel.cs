namespace TrickingLibrary.Models
{
    public abstract class BaseModel<Tkey>
    {
        public Tkey Id { get; set; }
        public bool Deleted { get; set; }
    }
}