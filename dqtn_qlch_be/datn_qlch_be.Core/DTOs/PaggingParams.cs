using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.DTOs
{
    public class PaggingParams
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Where { get; set; } = string.Empty;
        public string Sort { get; set; } = string.Empty;

    }
}
