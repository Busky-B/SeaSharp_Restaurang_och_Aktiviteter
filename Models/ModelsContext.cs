using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaSharp_Restaurang_och_Aktiviteter.Models
{
    public class ModelsContext : DbContext
    {
        public DbSet<Activity> Activities { get; set;}
        public DbSet<Menu> Menus { get; set;}
        public DbSet<MenuOptions> MenuOptions { get; set;}
        public DbSet<Reservation> Reservations { get; set;}

        public ModelsContext(DbContextOptions options) : base(options)
        {

        }
    }
}
