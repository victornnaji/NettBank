using NettBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NettBank.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<LoanOptions> options = new List<LoanOptions>()
            {
                new LoanOptions(){Name = "Business", icon="Business.svg"},
                new LoanOptions(){Name = "Property", icon="Property.svg"},
                new LoanOptions(){Name = "Car", icon="Car.svg"},
                new LoanOptions(){Name = "Student", icon="Student.svg"}
            };
            return View(options);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Options()
        {
            return View();
        }
    }
}