using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ayerwaves.Models
{
    public class Artist
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }
        public string StageName { get; set; }
        public string Day { get; set; }
        public string imageLink { get; set; }
    }
}
