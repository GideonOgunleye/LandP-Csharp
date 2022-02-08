using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.WebCrawler
{
    [DebuggerDisplay("{Href}, {Image}")]

    class Link
    {
        public string Links { get; set; }
        public string ImageUrl { get; set; }
    }
}
