using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaSharp_Restaurang_och_Aktiviteter.Models
{
    public class ActivityBooking
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int NumParticipants { get; set; }
      


        //lagt till keyn, annars blir det knasigt när  man försöker skapa en ny activitybooking via API
		public int ActivityId { get; set; }
		public Activity Activity { get; set; }
    }
}
