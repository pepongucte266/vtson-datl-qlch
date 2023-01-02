using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Enum
{
    public enum Sale
    {
        Available = 1,
        NotAvailable = 0
    }

    public enum ValidateMode
    {
        Insert = 1,
        Update = 2,
        Delete = 3,
        Login = 4
    }
}
