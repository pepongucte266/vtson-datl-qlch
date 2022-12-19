using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class Employee
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// Created By: VTSON (23/11/2022)
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// Created By: VTSON (23/11/2022)
        public string EmployeeName { get; set; } = String.Empty;

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
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// chức vụ
        /// </summary>
        /// Created By: VTSON (23/11/2022)
        public string Role { get; set; } = string.Empty;

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

    }
}
