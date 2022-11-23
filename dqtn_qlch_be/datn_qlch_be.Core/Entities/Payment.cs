using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class Payment
    {
        public Guid PaymentID { get; set; }

        public int PaymentType { get; set; }

        public string? PaymentName { get; set; }

        public int Inactive { get; set; }


    }
}
