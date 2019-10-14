using System;
using System.Collections.Generic;
using System.Text;

namespace GotWiki.Models
{
    public class Character
    {
        public string Name { get; set; }
        public IEnumerable<string> Aliases { get; set; }
        public IEnumerable<string> Titles { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public string Culture { get; set; }

        public string Gender { get; set; }
    }
}
