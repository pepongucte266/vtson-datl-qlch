using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class InvoiceDetail
    {
        public Guid InvoiceDetailID { get; set; }
        public Guid RefID { get; set; }
        public DateTime RefDate { get; set; }
        public Guid InventoryItemID { get; set; }
        public Guid PromotionID { get; set; }
        public decimal Quantity { get; set; }

    }
}
