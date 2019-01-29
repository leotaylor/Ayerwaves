using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ayerwaves.Models
{
    public class Vendor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
}
