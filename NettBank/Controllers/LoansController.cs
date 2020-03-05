using NettBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NettBank.Controllers
{
    public class LoansController : Controller
    {
        private ApplicationDbContext _context;

        public LoansController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Loans
        public ActionResult Index()
        {
            var loanCompanies = _context.LoanCompanies.OrderBy(x => x.InterestRate).ToList();
            return View(loanCompanies);

        }

        public ActionResult BusinessLoan()
        {
            return View();
        }

        public ActionResult PropertyLoan()
        {
            return View();
        }

        public ActionResult CarLoan()
        {
            return View();
        }

        public ActionResult StudentLoan()
        {
            return View();
        }

        public ActionResult SearchLoans(LoanTypeLoanCompanyViewModel search)
        {
            var Amount = search.LoanFormDto.Amount;
            var Interest = search.LoanFormDto.InterestRate;
            var Duration = search.LoanFormDto.Duration;
            var freq = search.LoanFormDto.RepaymentFrequency;
            var LType = search.LoanFormDto.LoanId;
            var ratings = search.LoanFormDto.Rating;

            var result = (from LoanCompany in _context.LoanCompanies
                          where (LoanCompany.MaxAmount >= Amount && LoanCompany.MinAmount <= Amount
                          && LoanCompany.InterestRate >= Interest && LoanCompany.MaxDuration == Duration
                          )
                          from LoanType in LoanCompany.LoanTypes
                          where (LoanType.Id == LType)
                          select LoanCompany).ToList();


            ViewBag.loanTitle = search.LoanFormDto.Loan.ToString();
            ViewBag.Money = Amount;

            //var Month = Duration * 12;
            //ViewBag.MonthlyPayment = 20000*((0.00625 * Math.Pow((1 + 0.00625), 60.0)) / (Math.Pow((1 + 0.00625), 60.0) - 1)); 
            return View(result);
        }
    }
}