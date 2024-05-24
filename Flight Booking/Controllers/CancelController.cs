using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightBooking.Models;

namespace FlightBooking.Controllers
{
    public class CancelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}