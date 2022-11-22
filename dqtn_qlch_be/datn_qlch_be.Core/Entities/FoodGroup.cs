using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class FoodGroup
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public Guid FoodGroupId { get; set; }
        /// <summary>
        /// Tên nhóm thực đơn
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string FoodGroupName { get; set; } = string.Empty;
        /// <summary>
        /// Mã nhóm thực đơn
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string FoodGroupCode { get; set; } = string.Empty;
        /// <summary>
        /// Khóa chính của nhóm cha
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public Guid? FoodGroupParentId { get; set; }
        /// <summary>
        /// Diễn giải
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string? FoodGroupDetail { get; set; }
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
