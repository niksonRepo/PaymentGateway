﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Types
{
    public class ReceiptDetails
    {
        public int ReceiptNumber { get; set; }
        public int UserId { get; set; }
        public double PayableAmount { get; set; }
        public int  PaymentStatus { get; set; }
    }
}
