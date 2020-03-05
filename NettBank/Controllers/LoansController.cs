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
             
            return View("SearchLoans", new List<LoanCompanyViewModel>());
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

            var results = (from LoanCompany in _context.LoanCompanies
                          where (LoanCompany.MaxAmount >= Amount && LoanCompany.MinAmount <= Amount
                          && LoanCompany.InterestRate >= Interest && LoanCompany.MaxDuration >= Duration
                          )
                          from LoanType in LoanCompany.LoanTypes
                          where (LoanType.Id == LType)
                          select LoanCompany).OrderBy(x => x.InterestRate).ToList();

            var LoanCompanyDto = new List<LoanCompanyViewModel>();

            var loanTypeString = new List<string>();
            foreach(var result in results)
            {
                LoanCompanyDto.Add(new LoanCompanyViewModel
                {
                    Id = result.Id,
                    Catch = result.Catch,
                    ComparisonRate = result.ComparisonRate,
                    ImagePath = result.ImagePath,
                    InterestRate = result.InterestRate,
                    MaxAmount = result.MaxAmount,
                    MaxDuration = result.MaxDuration,
                    MinAmount = result.MinAmount,
                    Name = result.Name,
                    Rating = result.Rating,
                    MonthlyRepayment = GetMonthly((long)Amount, result.InterestRate, (int)Duration),
                    RepaymentFrequency = result.RepaymentFrequency

                });
            }

            double GetMonthly(long P, double r, int n )
            {
                r = (r / 100) / 12;
                n = n * 12;

                double A = P * ((r * Math.Pow((1 + r), n)) / (Math.Pow((1 + r), n) - 1));

                return A;
            }

            ViewBag.duration = Duration;
            ViewBag.loanTitle = search.LoanFormDto.Loan.ToString();
            ViewBag.Money = Amount;

            return View(LoanCompanyDto);
        }
    }
}