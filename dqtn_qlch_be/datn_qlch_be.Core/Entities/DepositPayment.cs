using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class DepositPayment
    {
        public Guid DepositPaymentID { get; set; }
        public Guid DepositID { get; set; }
        public Guid PaymentID { get; set; }
        public decimal Amount { get; set; }

    }
}
