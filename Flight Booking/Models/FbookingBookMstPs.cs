using System;
using System.Collections.Generic;

namespace FlightBooking.Models
{
    public partial class FbookingBookMstPs
    {
        public string FlightId { get; set; }
        public string DepartureAp { get; set; }
        public string DestinationAp { get; set; }
        public DateTime? JourneyDate { get; set; }
        public decimal? Price { get; set; }
        public decimal? JourneyDuration { get; set; }
        
    }
}
