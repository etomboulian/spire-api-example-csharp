using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_example_csharp.SalesOrder
{
    public class SalesOrder
    {
        public int? id { get; set; }
        public Customer customer { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public bool hold { get; set; }
        public DateTime orderDate { get; set;}
        public DateTime requiredDate { get; set; }
        public string customerPO { get; set; }
        public List<SalesOrderItems> items { get; set;}
    }
}
