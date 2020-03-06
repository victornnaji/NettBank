using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NettBank.Models
{
    public class FormCompanyViewModel
    {
        public LoanFormDto LoanFormDto { get; set; }
        public List<LoanCompanyViewModel> LoanCompanyViewModels { get; set; }
    }
}