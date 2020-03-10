using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NettBank.Models
{
    public class RepaymentDetails
    {
        public double Payment { get; set; }
        public double Principal { get; set; }
        public double Interest { get; set; }
        public double Balance { get; set; }
    }
}