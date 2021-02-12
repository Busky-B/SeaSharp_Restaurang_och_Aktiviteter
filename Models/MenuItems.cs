using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaSharp_Restaurang_och_Aktiviteter.Models 
{


	// Ny Modell för MenuOptions => MenuItems
	public class MenuItems
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Allergies { get; set; }
        public decimal Price { get; set; }

		public int MenuCategoryId { get; set; }
		public MenuCategory MenuCategory{ get; set; }
	}
}
