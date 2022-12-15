using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class InventoryItem
    {
        public Guid InventoryItemID { get; set; }
        public string? InventoryItemCode { get; set; }
        public string? InventoryItemName { get; set; }
        public int InventoryItemType { get; set; }
        public decimal InventoryItemPrice { get; set; }
        public int Status { get; set; }
        public string? InventoryItemImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
