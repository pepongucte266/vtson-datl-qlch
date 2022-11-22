using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class FoodFavoriteService
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// Created By: VTSON (23/07/2022)
        public Guid FoodFavoriteServiceId { get; set; }
        /// <summary>
        /// Tên sở thích
        /// </summary>
        /// Created By: VTSON (23/07/2022)
        public string FavoriteServiceName { get; set; } = string.Empty;
        /// <summary>
        /// Giá tiền
        /// </summary>
        /// Created By: VTSON (23/07/2022)
        public decimal? FavoriteServicePrice { get; set; }
        /// <summary>
        /// Tên món
        /// </summary>
        /// Created By: VTSON (24/07/2022)
        public string FoodName { get; set; } = string.Empty;
        
        /// <summary>
        /// Khóa chính của món ăn
        /// </summary>
        /// Created By: VTSON (23/07/2022)
        public Guid? FoodId { get; set; }
        /// <summary>
        /// Khóa chính của sở thích
        /// </summary>
        /// Created By: VTSON (23/07/2022)
        public Guid? FavoriteServiceId { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// Created By: VTSON (23/07/2022)
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        /// Created By: VTSON (23/07/2022)
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        /// Created By: VTSON (23/07/2022)
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa đổi
        /// </summary>
        /// Created By: VTSON (23/07/2022)
        public string? ModifiedBy { get; set; }
    }
}
