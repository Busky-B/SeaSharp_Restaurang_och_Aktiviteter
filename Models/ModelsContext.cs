using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaSharp_Restaurang_och_Aktiviteter.Models
{
    public class ModelsContext : DbContext
    {
        public DbSet<Activity> Activities;
        public DbSet<Menu> Menus;
        public DbSet<MenuOptions> MenuOptions;
        public DbSet<Reservation> Reservations;

        public ModelsContext(DbContextOptions options) : base(options)
        {

        }
    }
}
