using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NettBank.Models
{
    public class LoanCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public double Rating { get; set; }
        public double InterestRate { get; set; }
        public double ComparisonRate { get; set; }
        [Required]
        public string RepaymentFrequency { get; set; }
        public int MaxDuration { get; set; }
        public long MaxAmount { get; set; }
        public long MinAmount { get; set; }

        [Required]
        public string ImagePath { get; set; }
        public string Catch { get; set; }
        public virtual ICollection<LoanType> LoanTypes { get; set; }
       

    }
}