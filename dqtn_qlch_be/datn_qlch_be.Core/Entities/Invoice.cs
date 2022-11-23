using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class Invoice
    {
        public Guid InvoiceID { get; set; }
        public string? InvoiceNo { get; set; }
        public int InvoiceType { get; set; }
        public decimal Amount { get; set; }
        public int IsCOD { get; set; }
        public decimal CODAmount { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public Guid PromotionID { get; set; }

    }
}
