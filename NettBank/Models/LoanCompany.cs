using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NettBank.Models
{
    public class LoanCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public double InterestRate { get; set; }
        public double ComparisonRate { get; set; }
        public string RepaymentFrequency { get; set; }
        public int MaxDuration { get; set; }
        public long MaxAmount { get; set; }
        public long MinAmount { get; set; }
        public string Catch { get; set; }
        public List<LoanType> LoanType { get; set; }

    }
}