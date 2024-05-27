using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public string Email { get; set; }

        [NotMapped]
        public decimal? PhoneNo { get; set; }

        [NotMapped]
        public decimal? Traveller { get; set; }

        [NotMapped]
        public string UserId { get; set; }
    }
}
