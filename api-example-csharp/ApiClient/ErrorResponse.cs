using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest.Client
{
    public class ErrorResponse
    {
        public string message { get; set; }
        public string error_type { get; set; }
        public string traceback { get; set; }
    }
}
