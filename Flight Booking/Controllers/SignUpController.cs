using System;
using Microsoft.AspNetCore.Mvc;
using FlightBooking.Models;

namespace FlightBooking.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ModelContext _context;
        public SignUpController(ModelContext context)
        {
            _context = context;
        }



        public IActionResult RegisteredUser(FBVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(obj.FbookingUserPsObj);
                    _context.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }

            catch (Exception)
            {
                return View("Index");
            }
            return View("Index");
        }
    }
}



//namespace FlightBooking.Controllers
//{
//    public class SignUpController : Controller
//    {
//        private readonly ModelContext _context;
//        public SignUpController(ModelContext context)
//        {
//            _context = context;
//        }   


//        public IActionResult Index()
//        {
//            return View();
//        }



//        public IActionResult RegisteredUser(FBVM obj)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    _context.Add(obj.FbookingUserPsObj);
//                    _context.SaveChanges();

//                    return RedirectToAction("Index", "Homepage");
//                }
//            }

//            catch (Exception ex)
//            {
//                return View("Index");
//            }
//            return View("Index");
//        }

//    }
//}