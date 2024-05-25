using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Models
{
    public class FbookingFinalPs
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string FlightId { get; set; }
        public decimal? PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public string DepartureAp { get; set; }
        public string DestinationAp { get; set; }
        public decimal? Traveller { get; set; }
        public DateTime? JourneyDate { get; set; }
        public decimal? Price { get; set; }
        
    }
}
