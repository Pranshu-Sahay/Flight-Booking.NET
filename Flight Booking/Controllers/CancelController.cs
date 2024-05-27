using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightBooking.Models;
using Microsoft.AspNetCore.Http;

namespace FlightBookingProj.Controllers
{
    public class CancelController : Controller
    {
        private readonly ModelContext _context;
        public CancelController(ModelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var UserId = HttpContext.Session.GetString("UserId");
            if (UserId != "null")
            {
                FBVM Obj = new FBVM();
                Obj.UserId = UserId;
                Obj.FbookingFinalPsList = _context.FbookingFinalPs.Where(x => x.UserId == UserId).ToList();
                return View(Obj);
            }
            else
            {
                var ErrorMsg = "INVALID";
                return RedirectToAction("Index", "Login", new { ErrorMsg = ErrorMsg });
            }

        }

        public IActionResult doCancel(int id)
        {
            try
            {
                FbookingFinalPs CancelObj = _context.FbookingFinalPs.SingleOrDefault(x => x.BookingId == id);
                CancelObj.BookingStatus = "I";
                _context.Update(CancelObj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index", "Cancel");
        }

    }
}

