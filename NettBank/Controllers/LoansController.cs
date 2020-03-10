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

            Session["searchAmount"] = search.LoanFormDto.Amount;
            Session["searchDuration"] = search.LoanFormDto.Duration;
            Session["loantype"] = search.LoanFormDto.Loan;



            var results = (from LoanCompany in _context.LoanCompanies
                          where (LoanCompany.MaxAmount >= Amount && LoanCompany.MinAmount <= Amount
                          && LoanCompany.InterestRate >= Interest && LoanCompany.MaxDuration >= Duration
                          )
                          from LoanType in LoanCompany.LoanTypes
                          where (LoanType.Id == LType)
                          select LoanCompany).OrderBy(x => x.InterestRate).ToList();

            //var LoanCompanyDto = new List<LoanCompanyViewModel>();

            var LoanCompanyDto = new FormCompanyViewModel();

            LoanCompanyDto.LoanCompanyViewModels = new List<LoanCompanyViewModel>();

            var loanTypeString = new List<string>();
            foreach(var result in results)
            {
               
                LoanCompanyDto.LoanCompanyViewModels.Add(new LoanCompanyViewModel
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

            ViewBag.duration = Duration;
            ViewBag.loanTitle = search.LoanFormDto.Loan;
            ViewBag.Money = Amount;
            ViewBag.Id = LType;

            return View(LoanCompanyDto);
        }

        double GetMonthly(long P, double r, int n)
        {
            r = (r / 100) / 12;
            n = n * 12;

            return P * ((r * Math.Pow((1 + r), n)) / (Math.Pow((1 + r), n) - 1));
        }

        double GetTotalAmount(double M, int n)
        {
            return M * n;
        }

        [Authorize]
        public ActionResult LoanDetail(int Id)
        {
            var Amount = Session["searchAmount"];
            var Duration = Session["SearchDuration"];
            var loanType = Session["loantype"];

            var stringAmount = Session["searchAmount"].ToString();

            double Amounts = double.Parse(stringAmount);
            int Durations = (int)Duration;

            var result = _context.LoanCompanies.Where(x => x.Id == Id).SingleOrDefault();

            var monthlyAmount = GetMonthly((long)Amounts, result.InterestRate, (int)Duration);

            var duration = int.Parse(Duration.ToString()) * 12;

            var totalAmount = GetTotalAmount(monthlyAmount, duration);

            var yearlyAmount = monthlyAmount * 12;

            var repayments = new List<RepaymentDetails>();



            int count = 1;
            double new_balance, interest_paid, principal_paid;

            while(Amounts > 0.00)
            {
                new_balance = Amounts;

                interest_paid = new_balance * ((result.InterestRate / 100) / 12);
                principal_paid = monthlyAmount - interest_paid;
                Amounts = new_balance - principal_paid;


                if ((new_balance + interest_paid) <= monthlyAmount && count == 12 * (int)Duration)
                {
                    repayments.Add(new RepaymentDetails
                    {
                        Payment = new_balance + interest_paid,
                        Interest = interest_paid,
                        Principal = new_balance - interest_paid,
                        Balance = 0.00
                    }); ;
                }
                else
                {
                    repayments.Add(new RepaymentDetails
                    {
                        Payment = monthlyAmount,
                        Interest = interest_paid,
                        Principal = principal_paid,
                        Balance = Amounts
                    });
                }

                count++;
                


            }

            var companyDto = new LoanCompanyViewModel()
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
                MonthlyRepayment = monthlyAmount,
                RepaymentFrequency = result.RepaymentFrequency,
                RepaymentDetails = repayments,
            };

            ViewBag.Amount = Amount;
            ViewBag.Duration = Duration;
            ViewBag.loanType = loanType;


            return View(companyDto);
        }

    }
}