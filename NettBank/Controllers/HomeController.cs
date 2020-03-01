using NettBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NettBank.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index()
        {
            List<LoanOptions> options = new List<LoanOptions>()
            {
                new LoanOptions(){Name = "Business", icon="Business.svg"},
                new LoanOptions(){Name = "Property", icon="Property.svg"},
                new LoanOptions(){Name = "Car", icon="Car.svg"},
                new LoanOptions(){Name = "Student", icon="Student.svg"}
            };

            var loanCompanies = _context.LoanCompanies.OrderBy(x => x.InterestRate).Take(4).ToList();


            var OptionCompany = new OptionCompanyViewModel
            {
                LoanOptions = options,
                LoanCompanies = loanCompanies
            };


            return View(OptionCompany);
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