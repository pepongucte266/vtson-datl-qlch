using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Entities
{
    public class DBOption
    {
        public Guid DBOptionID { get; set; }
        public string? OptionName { get; set; }
        public string? OptionValue { get; set; }
        public string? Description { get; set; }
    }
}
