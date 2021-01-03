using System.Security.AccessControl;

namespace TrickingLibrary.Api.Models
{
    public class Trick
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Video { get; set; }
    }
}