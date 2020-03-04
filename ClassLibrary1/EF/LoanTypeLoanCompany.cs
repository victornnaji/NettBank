namespace ClassLibrary1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LoanTypeLoanCompany
    {
        public int Id { get; set; }

        public int LoanType_Id { get; set; }

        public int LoanCompany_Id { get; set; }

        public virtual LoanCompany LoanCompany { get; set; }

        public virtual LoanType LoanType { get; set; }
    }
}
