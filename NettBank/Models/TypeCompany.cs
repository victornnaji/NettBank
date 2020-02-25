using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NettBank.Models
{
    public class TypeCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanTypeId { get; set; }
        public LoanType loanType { get; set; }

        public int LoanCompanyId { get; set; }
        public LoanCompany LoanCompany { get; set; }
    }
}