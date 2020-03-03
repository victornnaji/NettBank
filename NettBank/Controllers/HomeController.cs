using NettBank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var optionFromDatabase = _context.LoanTypes.ToList();

            var optionsDto = new List<LoanOptions>();
                
            foreach(var option in optionFromDatabase)
            {
                optionsDto.Add(new LoanOptions { Name = option.Name, icon = option.Icon, Id = option.Id });
            };
                    
              
            var loanCompanies = _context.LoanCompanies.OrderBy(x => x.InterestRate).Take(4).ToList();


            var OptionCompany = new OptionCompanyViewModel
            {
                LoanOptions = optionsDto,
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

        public ActionResult LoanForm(int Id)
        {   
            var loanType = _context.LoanTypes.SingleOrDefault(c => c.Id == Id);

            var TypeCompany = new LoanTypeLoanCompanyViewModel
            {
                LoanType = loanType,
                LoanFormDto = new LoanFormDto()
            };

            return PartialView("_LoanForm", TypeCompany);
        }
    }
}