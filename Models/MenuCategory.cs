﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SeaSharp_Restaurang_och_Aktiviteter.Models
{
    public class MenuCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        [JsonIgnore]
        public List<MenuItems> MenuItems { get; set; }
    }
}
