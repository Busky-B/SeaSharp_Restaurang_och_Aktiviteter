using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaSharp_Restaurang_och_Aktiviteter.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
    }
}
