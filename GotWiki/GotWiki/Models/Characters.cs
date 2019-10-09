using System;
using System.Collections.Generic;
using System.Text;

namespace GotWiki.Models
{
    public class Characters
    {
        public string Name { get; set; }
        public IEnumerable<string> Aliases { get; set; }
        public IEnumerable<string> Titles { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public string Culture { get; set; }
    }
}
