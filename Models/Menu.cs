using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeaSharp_Restaurang_och_Aktiviteter.Models;

namespace SeaSharp_Restaurang_och_Aktiviteter.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuOptions> MenuOptions { get; } = new List<MenuOptions>();
    }
}
