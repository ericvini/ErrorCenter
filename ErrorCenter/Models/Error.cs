using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorCenter.Models
{
    public class Error
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EventsCount { get; set; }
        public string Level { get; set; }
    }
}
