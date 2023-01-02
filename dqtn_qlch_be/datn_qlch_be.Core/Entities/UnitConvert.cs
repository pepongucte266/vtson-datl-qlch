using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class UnitConvert
    {
        public Guid UnitConvertID { get; set; }
        public Guid InventoryItemID { get; set; }
        public Guid InventoryItemUnitID { get; set; }
        public decimal UnitConvertRate { get; set; }
        public decimal UnitConvertPrice { get; set; }
        public int UnitConvertType { get; set; }
        public decimal UnitConvertSaleDefault { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }


    }
}
