using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeaSharp_Restaurang_och_Aktiviteter.Models;

namespace SeaSharp_Restaurang_och_Aktiviteter.Models
{
    //a
    public class ModelsContext : DbContext
    {
        public DbSet<Activity> Activities { get; set;}
        public DbSet<Menu> Menus { get; set;}
        public DbSet<MenuItems> MenuItems { get; set;}
        public DbSet<Reservation> Reservations { get; set;}
        public DbSet<MenuCategory> MenuCategory { get; set; }
        public DbSet<ActivityBooking> ActivityBooking { get; set; }


        public ModelsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<SeaSharp_Restaurang_och_Aktiviteter.Models.Reservation> Reservation { get; set; }
    }
}
