namespace ClassLibrary1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LoanCompany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoanCompany()
        {
            LoanTypeLoanCompanies = new HashSet<LoanTypeLoanCompany>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanTypeLoanCompany> LoanTypeLoanCompanies { get; set; }
    }
}
