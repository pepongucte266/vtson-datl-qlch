using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class Customer
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// Created By: VTSON (23/11/2022)
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        /// Created By: VTSON (23/11/2022)
        public string? CustomerName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// Created By: VTSON (23/11/2022)
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// địa chỉ
        /// </summary>
        /// Created By: VTSON (23/11/2022)
        public string? Address { get; set; }

        /// <summary>
        /// sdt
        /// </summary>
        /// Created By: VTSON (23/11/2022)
        public string? PhoneNumber { get; set; }

    }
}
