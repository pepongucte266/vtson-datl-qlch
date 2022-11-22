using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Exceptions
{
    public class MISAValidateException : Exception
    {
        string _msg;
        IDictionary _data;
        public MISAValidateException(string msg, List<string>? data)
        {
            _msg = msg;
            _data = new Dictionary<string, List<string>>();
            _data.Add("errors", data);
        }

        public override string Message => _msg;
        public override IDictionary Data => _data;
    }
}
