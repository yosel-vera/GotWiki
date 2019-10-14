using System;
using System.Collections.Generic;
using System.Text;

namespace GotWiki.Models
{
    public class House
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string CoatOfArms { get; set; }
        public string Words { get; set; }
        public string Founded { get; set; }
        public IEnumerable<string> Titles { get; set; }
        public IEnumerable<string> Seats { get; set; }

        public IEnumerable<string> AncestralWeapons { get; set; }

        public string CurrentLord { get; set; }
    }
}
