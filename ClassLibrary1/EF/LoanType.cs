namespace ClassLibrary1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LoanType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoanType()
        {
            LoanTypeLoanCompanies = new HashSet<LoanTypeLoanCompany>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Icon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanTypeLoanCompany> LoanTypeLoanCompanies { get; set; }
    }
}
