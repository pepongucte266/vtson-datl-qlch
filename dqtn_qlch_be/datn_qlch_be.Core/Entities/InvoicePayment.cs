using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class InvoicePayment
    {
        public Guid InvoicePaymentID { get; set; }
        /// <summary>
        /// ID chứng từ
        /// </summary>
        public Guid RefID { get; set; }
        public Guid PaymentID { get; set; }
        public decimal Amount { get; set; }
        public int PaymentType { get; set; }
    }
}
