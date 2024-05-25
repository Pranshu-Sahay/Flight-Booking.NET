using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace FlightBooking.Controllers
{
    public class HomeController : Controller
    {

        private readonly ModelContext _context;
        public HomeController(ModelContext context)
        {
            _context = context;
        }


        public IActionResult Index(FBVM Obj)
        {
            var UserId = HttpContext.Session.GetString("UserId");
            if (UserId == null)
            {
                Obj.UserId = "null";
                Obj.Username = "null";
            }
            else
            {
                Obj.UserId = UserId;
                Obj.Username = _context.FbookingUserPs.SingleOrDefault(x => x.UserId == UserId).Username;
                ViewBag.AirportList = GetDestinations();
            }
            if (Obj.FbookingBookMstPsList == null)
            {
                Obj.FbookingBookMstPsList = new List<FbookingBookMstPs>();
            }
            
            return View(Obj);
        }

        public List<SelectListItem> GetDestinations()
        {
            var list = (from a in _context.FbookingDestMstPs
                        select new SelectListItem
                        {
                            Value = a.DestinationCode,
                            Text = a.DestinationCode.ToString() + "_" + a.Description.ToString()
                        }).ToList();

            return list;
        }

        public IActionResult SearchFlights(FBVM Obj)
        {
            try
            {
                    Obj.FbookingBookMstPsList = _context.FbookingBookMstPs.
                                                Where(x => x.DepartureAp == Obj.FbookingBookMstPsObj.DepartureAp && x.DestinationAp == Obj.FbookingBookMstPsObj.DestinationAp
                                                && x.JourneyDate == Obj.FbookingBookMstPsObj.JourneyDate).ToList();
            }
            catch (Exception ex)
            {
            }
            return View("Index",Obj);
            //return RedirectToAction("Index", "Home", new{ Flight = FlightList });
        }


        public bool IsAuthenticated(string username, string password)
        {
            try
            {
               
                var user = _context.FbookingUserPs.FirstOrDefault(u => u.Username == username && u.Password == password);
                return user != null; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking authentication: " + ex.Message);
                return false; 
            }
        }      
        



        public IActionResult BookFlight(FBVM Obj)
        {
            var username = HttpContext.Session.GetString("Username");         
            var user = _context.FbookingUserPs.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {               
                return RedirectToAction("Index");
            }

           
            string userId = user.UserId;            
            var DtlObj = _context.FbookingBookMstPs.SingleOrDefault(x=>x.FlightId== Obj.FlightId);            
            //string message = $"Congratulations {userId}! Your ticket has been booked with {flightDetails}. <a href='/MyBookings'>Go To My Bookings</a>";

            

            string SuccessMessage = "SUCCESS";

            
            return RedirectToAction("Index",new { message = SuccessMessage});
        }
     
        private string GetFlightDetails(string flightId)
        {
            
            return $"Flight ID: {flightId}"; 
        }

    }
        
    
   



    //public IActionResult Index(FBVM Obj)
    //{


    //    return View(Obj);
    //}





    //public IActionResult Index()
    //{
    //    var Username = HttpContext.Session.GetString("Username");
    //    FBVM Obj = new FBVM();
    //    if (Username == null)
    //    {
    //        Obj.Username = "null";
    //    }
    //    else
    //    {
    //        Obj.Username = Username;
    //        ViewBag.AirportList = GetDestinations();
    //    }
    //    return View(Obj);
    //}

    //public IActionResult Search(FBVM Obj)
    //{
    //    try
    //    {
    //        //Obj.FbookingBookMstPsList = _context.FbookingBookMstPs.
    //        //                        Where(x => x.DepartureAp == Obj.FbookingBookMstPsObj.DepartureAp == Obj.FbookingBookMstPsObj.DestinationAp && x.JourneyDate == Obj.FbookingBookMstPsObj.JourneyDate).ToList();
    //    }
    //    catch (Exception)
    //    {

    //    }
    //    return View(Obj);
    //}


    //public IActionResult Logout()
    //{
    //    // Invalidate the user session
    //    HttpContext.Session.Clear();

    //    // Redirect the user to the login or sign-up page
    //    return RedirectToAction("Index", "Home"); 
    //}


    //public IActionResult SearchFlights(FBVM Obj)
    //{
    //    List<FbookingBookMstPs> FlightList = new List<FbookingBookMstPs>();
    //    try
    //    {
    //        FlightList = _context.FbookingBookMstPs.Where(x => x.DepartureAp == Obj.FbookingBookMstPsObj.DepartureAp && x.DestinationAp == Obj.FbookingBookMstPsObj.DestinationAp && x.JourneyDate == Obj.FbookingBookMstPsObj.JourneyDate).ToList();
    //        Obj.FbookingBookMstPsList = FlightList;
    //    }
    //    catch(Exception)
    //    {

    //    }
    //    return RedirectToAction("Index", "Search", new { Flight = FlightList });
    //}








    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
}

