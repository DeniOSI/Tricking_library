using System.Collections.Generic;
using TrickingLibrary.Api.Models;

namespace TrickingLibrary.Api
{
    public class TrickyStore
    {
        private readonly List<Trick> _tircks;

        public TrickyStore()
        {
            _tircks = new List<Trick>();
        }

        public IEnumerable<Trick> All() => _tircks;

        public void Add(Trick trick)
        {
            trick.Id = _tircks.Count + 1;
            _tircks.Add(trick);
        }
        
        
    }
}