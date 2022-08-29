using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HelpModel
{
    public class SearchModel
    {
        public string ByWhat { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? KeyWords { get; set; }
        public string? Category { get; set; }
        public DateTime? PublishDate { get; set; }
        public double? Price { get; set; }

    }
}
