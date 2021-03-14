using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Api.Filters;
using PaymentGateway.Api.Types;

namespace PaymentGateway.Api.Controllers
{
    [ApiController]
    [Route ( "[controller]" )]
    public class GatewayController : Controller
    {
        [HttpGet]
        [ApiKeyAuth]
        public IActionResult Get ( BillingDetails billingDetails )
        {
            return Ok ( new ReceiptDetails ()
            {
                PayableAmount = billingDetails.PayableAmount,
                ReceiptNumber = new Random ().Next ( 1, 10 ),
                UserId = billingDetails.UserId,
                PaymentStatus = (int) PaymentStatus.Success
            } );
        }
    }
}