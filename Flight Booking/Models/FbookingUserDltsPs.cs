using System;
using System.Collections.Generic;

namespace FlightBooking.Models
{
    public partial class FbookingUserDltsPs
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public decimal? PhoneNo { get; set; }
        public DateTime? Dob { get; set; }
    }
}
