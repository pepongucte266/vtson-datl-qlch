using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class Deposit
    {
        public Guid DepositID { get; set; }
        public string? DepositNo { get; set; }
        public Guid RefID { get; set; }
        public DateTime RefDate { get; set; }
        public Guid CustomerID { get; set; }
        public Guid EmployeeID { get; set; }

    }
}
