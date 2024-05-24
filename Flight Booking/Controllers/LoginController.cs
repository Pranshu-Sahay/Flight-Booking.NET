using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightBooking.Models;
using Microsoft.AspNetCore.Http;

namespace FlightBooking.Controllers
{
    public class LoginController : Controller
    {
        private readonly ModelContext _context;
        public LoginController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(FBVM obj)
        {
            try
            {
                var enteredpassword = obj.FbookingUserPsObj.password;
                var exists = _context.FbookingUserPs.Any(x => x.UserId == obj.FbookingUserPsObj.UserId);
                if (exists)
                {
                    var registeredpass = _context.FbookingUserPs.SingleOrDefault(x => x.UserId == obj.FbookingUserPsObj.UserId).password;
                    if (enteredpassword == registeredpass)
                    {
                        HttpContext.Session.SetString("UserId", obj.FbookingUserPsObj.UserId);
                        return RedirectToAction("index", "home");
                    }
                }

                //var Enteredpassword = obj.FbookingUserPsObjObj.Password;
                //var exists = _context.FbookingUserPsObj.Any(x => x.Username == obj.FbookingUserPsObjObj.Username);
                //if (exists)
                //{
                //    var Registeredpass = _context.FbookingUserPsObj.SingleOrDefault(x => x.Username == obj.FbookingUserPsObjObj.Username).Password;
                //    if (Enteredpassword == Registeredpass)
                //    {
                //        HttpContext.Session.SetString("Username", obj.FbookingUserPsObjObj.Username);
                //        return RedirectToAction("Index", "Home");
                //    }
                //}
            }

            catch (Exception)
            {
                return View("Index");
            }
            return View("Index");
        }
    }
}

