using System;
using System.Collections.Generic;

namespace FlightBooking.Models
{
    public partial class FbookingBookDltsPs
    {
        public string FlightId { get; set; }
        public decimal? Traveller { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
