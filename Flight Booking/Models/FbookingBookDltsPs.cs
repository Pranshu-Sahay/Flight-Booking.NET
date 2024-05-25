using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBooking.Models
{
    public partial class FbookingBookDltsPs
    {
        public string FlightId { get; set; }
        public decimal? Traveller { get; set; }
        public DateTime? ReturnDate { get; set; }

        [NotMapped]
        public string UserId { get; set; }

        [NotMapped]
        public decimal? PhoneNo { get; set; }

        [NotMapped]
        public string Email { get; set; }

        [NotMapped]
        public DateTime? Dob { get; set; }

        [NotMapped]
        public string DestinationCode { get; set; }

        [NotMapped]
        public DateTime? JourneyDate { get; set; }






    }



}
