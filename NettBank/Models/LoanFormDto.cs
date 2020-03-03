using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NettBank.Models
{
    public class LoanFormDto
    {
        [Display(Name = "How much do you need?")]
        public long? Amount { get; set; }

        [Display(Name = "Type of loan?")]
        public LoanType Loan { get; set; }

        [Display(Name = "interest rate?")]
        public double? InterestRate { get; set; }

        [Display(Name = "Loan Length?")]
        public int Duration { get; set; }

        [Display(Name = "Repayment?")]
        public Frequency RepaymentFrequency { get; set; }

        [Display(Name = "Ratings? >")]
        public LoanRatings Rating { get; set; }
    }

    public enum Frequency
    {
        Monthly,
        Quarterly,
        Yearly

    }

    public enum LoanRatings
    {
        one = 1,
        two = 2,
        three = 3,
        four = 4,
        five = 5
    }
}