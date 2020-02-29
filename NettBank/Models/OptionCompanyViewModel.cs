using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NettBank.Models
{
    public class OptionCompanyViewModel
    {
        public List<LoanOptions> LoanOptions { get; set; }
        public List<LoanCompany> LoanCompanies { get; set; }
    }
}