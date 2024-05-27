using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FlightBooking.Models;

namespace FlightBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly ModelContext _context;
        public BookingController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index(string FlightId, DateTime DepDate)
        {
            var UserId = HttpContext.Session.GetString("UserId");

            FBVM Obj = new FBVM();
            Obj.UserId = UserId;
            Obj.FbookingUserPsObj = _context.FbookingUserPs.SingleOrDefault(X => X.UserId == UserId);
            Obj.FbookingBookMstPsObj = (from a in _context.FbookingBookMstPs.Where(X => X.FlightId == FlightId)
                                   select new FbookingBookMstPs
                                   {
                                       Price = a.Price,
                                       FlightId = a.FlightId,
                                       JourneyDate = a.JourneyDate,
                                       JourneyDuration = a.JourneyDuration,
                                       DepartureAp = _context.FbookingDestMstPs.SingleOrDefault(x => x.DestinationCode == a.DepartureAp).Description,
                                       DestinationAp = _context.FbookingDestMstPs.SingleOrDefault(x => x.DestinationCode == a.DestinationAp).Description,
                                   }).SingleOrDefault();

            return View(Obj);
        }

        public IActionResult BookFlight(FBVM Obj)
        {
            var UserId = HttpContext.Session.GetString("UserId");
            var UserName = _context.FbookingUserPs.FirstOrDefault(u => u.UserId == UserId).Username;
            string SuccessMessage = string.Empty;
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        string userId = UserId;
                        var BookId = _context.FbookingFinalPs.Select(x => x.BookingId).DefaultIfEmpty(0).Max();
                        //var DtlObj = _context.FbookingBookMstPs.SingleOrDefault(x => x.FlightId == Obj.FlightId);
                        FbookingFinalPs InsObj = new FbookingFinalPs();
                        InsObj.BookingId = BookId + 1;
                        InsObj.UserId = Obj.FbookingBookMstPsObj.UserId;
                        InsObj.Username = UserName;
                        InsObj.FlightId = Obj.FbookingBookMstPsObj.FlightId;
                        InsObj.DepartureAp = Obj.FbookingBookMstPsObj.DepartureAp;
                        InsObj.DestinationAp = Obj.FbookingBookMstPsObj.DestinationAp;
                        InsObj.JourneyDate = Obj.FbookingBookMstPsObj.JourneyDate;
                        var Price = _context.FbookingBookMstPs.SingleOrDefault(x => x.FlightId == Obj.FbookingBookMstPsObj.FlightId).Price;
                        var TotalPrice = (Obj.FbookingBookMstPsObj.Traveller * Price);
                        InsObj.Price = TotalPrice;
                        InsObj.JourneyDuration = Obj.FbookingBookMstPsObj.JourneyDuration;
                        InsObj.Email = Obj.FbookingUserDltsObj.Email;
                        InsObj.PhoneNo = Obj.FbookingUserDltsObj.PhoneNo;
                        InsObj.Traveller = Obj.FbookingBookMstPsObj.Traveller;
                        _context.Add(InsObj);
                        _context.SaveChanges();
                        SuccessMessage = "SUCCESS";
                    }
                    catch (Exception ex)
                    {
                        SuccessMessage = "FAILED";
                    }
                }
            }
            return RedirectToAction("Index", new { message = SuccessMessage });
        }

        public IActionResult doBook(FBVM Obj)
        {
            try
            {
                var UserId = HttpContext.Session.GetString("UserId");

                Obj.UserId = UserId;
                var BookId = _context.FbookingFinalPs.Select(x => x.BookingId).DefaultIfEmpty(0).Max();

                FbookingFinalPs InsObj = new FbookingFinalPs();


                InsObj.BookingId = BookId + 1;
                InsObj.UserId = Obj.UserId;
                InsObj.JourneyDuration = Obj.FbookingBookMstPsObj.JourneyDuration;
                InsObj.FlightId = Obj.FbookingBookMstPsObj.FlightId;
                InsObj.DepartureAp = Obj.FbookingBookMstPsObj.DepartureAp;
                InsObj.DestinationAp = Obj.FbookingBookMstPsObj.DestinationAp;
                InsObj.Email = Obj.FbookingBookMstPsObj.Email;
                InsObj.PhoneNo = Obj.FbookingBookMstPsObj.PhoneNo;
                InsObj.Traveller = Obj.FbookingBookMstPsObj.Traveller;
                InsObj.BookingStatus = "A";
                var Price = _context.FbookingBookMstPs.SingleOrDefault(x => x.FlightId == Obj.FbookingBookMstPsObj.FlightId).Price;
                var TotalPrice = (Obj.FbookingBookMstPsObj.Traveller * Price);
                InsObj.Price = TotalPrice;

                _context.Add(InsObj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index", "Home");
        }
    }
}