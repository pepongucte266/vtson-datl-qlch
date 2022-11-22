using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class FoodUnit
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public Guid FoodUnitId { get; set; }
        /// <summary>
        /// Đơn vị tính
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string FoodUnitName { get; set; } = string.Empty;
        /// <summary>
        /// Diễn giải
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string? FoodUnitDetail { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa đổi
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string? ModifiedBy { get; set; }
    }
}
