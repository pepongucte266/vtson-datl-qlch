using datn_qlch_be.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class Food
    {

        /// <summary>
        /// Khóa chính
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public Guid FoodId { get; set; }
        /// <summary>
        /// Tên giới tính
        /// </summary>
        /// Created By: VTSON (12/06/2022)
        public string FoodStopSaleName
        {
            get
            {
                switch (FoodStopSale)
                {
                    case Enum.Sale.Available:
                        return "Đang bán";
                    case Enum.Sale.NotAvailable:
                        return "Ngừng kinh doanh";
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// Tên loại món
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string? FoodCategoryName { get; set; }
        /// <summary>
        /// Tên nhóm món
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string? FoodGroupName { get; set; }
        /// <summary>
        /// Thứ tự món
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string? FoodSequenceName { get; set; }
        /// <summary>
        /// Tên đơn vị tính
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string FoodUnitName { get; set; } = string.Empty;
        /// <summary>
        /// Nơi chế biến
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string? FoodPlaceName { get; set; }
        /// <summary>
        /// Mã món
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string FoodCode { get; set; } = string.Empty;
        /// <summary>
        /// Tên món
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string FoodName { get; set; } = string.Empty;
        /// <summary>
        /// Id loại món
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public Guid? FoodCategoryId { get; set; }
        /// <summary>
        /// Id nhóm món
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public Guid? FoodGroupId { get; set; }
        /// <summary>
        /// Id đơn vị tính
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public Guid? FoodUnitId { get; set; }
        /// <summary>
        /// Id nơi chế biến
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public Guid? FoodPlaceId { get; set; }
        /// <summary>
        /// Id thứ tự món
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public Guid? FoodSequenceId { get; set; }
        /// <summary>
        /// Giá bán
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public decimal? FoodSellPrice { get; set; }
        /// <summary>
        /// Giá vốn
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public decimal? FoodCostPrice { get; set; }
        /// <summary>
        /// Mô tả món ăn
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string? FoodDetail { get; set; }
        /// <summary>
        /// Thuế
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public double? FoodTax { get; set; }
        /// <summary>
        /// Điều chỉnh giá tự do
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public int? FoodFreeChangePrice { get; set; }
        /// <summary>
        /// Định lượng nguyên vật liệu
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string FoodQuantity { get; set; } = string.Empty;
        /// <summary>
        /// Hiển thị trên menu
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public int? FoodShowInMenu { get; set; }
        /// <summary>
        /// Dừng bán
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public Sale? FoodStopSale { get; set; }
        /// <summary>
        /// Link ảnh
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        public string? FoodAvatar { get; set; }
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
