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
            
            //var result = (from LoanCompany in _context.LoanCompanies 
            //              where( LoanCompany.MaxAmount >= Amount && LoanCompany.MinAmount <= Amount
            //              && LoanCompany.InterestRate == Interest && LoanCompany.MaxDuration == Duration
            //              && LoanCompany.RepaymentFrequency.Equals(freq)
            //              )
            //              from LoanType in LoanCompany.LoanTypes
            //              where (LoanType.Id == LType)
            //              select new
            //              {
            //                  LoanCompany.Name,
            //                  LoanCompany.Rating,
            //                  LoanCompany.Catch,
            //                  LoanCompany.ComparisonRate,
            //                  LoanCompany.ImagePath,
            //                  LoanCompany.InterestRate,
            //                  LoanCompany.MaxAmount,
            //                  LoanCompany.MaxDuration,
            //                  LoanCompany.MinAmount,
            //                  LoanCompany.RepaymentFrequency

            //              }).ToList();
            //var res = _context.LoanCompanies.Where(lc => lc.MaxAmount >= Amount && lc.MinAmount <= Amount
            //&& lc.InterestRate >= Interest && lc.MaxDuration >= Duration) && _context.LoanTypes.Where( lt => lt.Id == LType)).ToList();

            return View();
        }
    }
}