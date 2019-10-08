using System;
using System.Collections.Generic;
using System.Text;

namespace GotWiki.Models
{
    public class Books
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public string Country { get; set; }



    }
}
