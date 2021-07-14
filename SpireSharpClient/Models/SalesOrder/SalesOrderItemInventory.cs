using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_example_csharp.SalesOrder
{
    public class SalesOrderItemInventory
    {
        public int? id { get; set; }
        public string whse { get; set; }
        public string partNo { get; set; }
        public string description { get; set; }
    }
}
