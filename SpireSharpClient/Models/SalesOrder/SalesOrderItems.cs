using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_example_csharp.SalesOrder
{
    public class SalesOrderItems
    {
        public int? id { get; set; }
        public string partNo { get; set; }
        public SalesOrderItemInventory inventory { get; set; }
        public string whse { get; set; }
        public int orderQty { get; set; }
        public int committedQty { get; set; }
        public string sellMeasure { get; set; }
        public decimal unitPrice { get; set; }
    }
}
