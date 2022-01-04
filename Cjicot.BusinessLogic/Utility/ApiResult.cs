using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Presentation.Utility
{
    public class ApiResult<T>: ApiResult
    {
        public T data { get; set; }
    }

    public class ApiResult
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}
