using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Types
{
    public class BillingDetails
    {
        public int OrderNumber { get; set; }
        public int UserId { get; set; }
        public double PayableAmount { get; set; }
        public int PaymentGateway { get; set; }
        public string OptionalDescription { get; set; }
    }
}