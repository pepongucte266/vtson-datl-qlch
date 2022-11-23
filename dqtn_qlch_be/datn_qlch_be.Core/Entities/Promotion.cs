using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class Promotion
    {
        public Guid PromotionID { get; set; }
        public string? Description { get; set; }
        public string? PromotionName { get; set; }
        public int PromotionType { get; set; }

    }
}
