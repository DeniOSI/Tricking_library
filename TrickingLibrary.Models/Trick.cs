using System.Collections;
using System.Collections.Generic;

namespace TrickingLibrary.Models
{
    public class Trick : BaseModel<string>
    {
        public string Name { get; set; }
        public string DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }

        public IList<TrickRelationship> Progressions { get; set; }
        public IList<TrickRelationship> Prerequisites { get; set; }

        public IList<TrickCategory> TrickCategories { get; set; }
    }
}