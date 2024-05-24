using System;
using System.Collections.Generic;

namespace FlightBooking.Models
{
    public partial class FbookingUserPs
    {
        internal object password;

        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
