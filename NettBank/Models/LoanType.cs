using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NettBank.Models
{
    public class LoanType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Icon { get; set; }
        public virtual ICollection<LoanCompany> LoanCompanies { get; set; }
    }
}