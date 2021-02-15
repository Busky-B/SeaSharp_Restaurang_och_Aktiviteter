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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        // Listan behövs för att underlätta vid sökandet av vad som är bokat till vilken aktivitet.
        public List<ActivityBooking> ActivityBookings{ get; } = new List<ActivityBooking>();


    }
}
