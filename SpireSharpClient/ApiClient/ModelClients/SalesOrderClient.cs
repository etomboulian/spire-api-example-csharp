using api_example_csharp.SalesOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest.Client
{
    public class SalesOrderClient : BaseObjectClient<SalesOrder>
    {
        public SalesOrderClient(ApiClient client) : base(client) { }

        public override string Resource
        {
            get
            {
                return "sales/orders/";
            }
        }
    }
}
