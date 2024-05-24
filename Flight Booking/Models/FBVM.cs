using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBooking.Models;

namespace FlightBooking.Models
{
    public class FBVM
    {
        public FbookingUserPs FbookingUserPsObj { get; set; }
        public List<FbookingUserPs> FbookingUserPsList { get; set; }

        public FbookingUserDltsPs FbookingUserDltsObj { get; set; }
        public List<FbookingUserDltsPs> FbookingUserDltsPsList { get; set; }

        public FbookingDestMstPs FbookingDestMstPsObj { get; set; }
        public List<FbookingDestMstPs> FbookingDestMstPsList { get; set; }

        public FbookingBookMstPs FbookingBookMstPsObj { get; set; }
        public List<FbookingBookMstPs> FbookingBookMstPsList { get; set; }

        public FbookingBookDltsPs FbookingBookDltsPsObj { get; set; }
        public List<FbookingBookDltsPs> FbookingBookDltsPsList { get; set; }

        public string UserId { get; set; }

        //public string Username { get; set; }

    }
}
