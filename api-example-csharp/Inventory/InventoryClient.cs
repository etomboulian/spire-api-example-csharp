using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiTest.Client;

namespace ApiTest.InventoryApi
{
    public class InventoryClient : BaseObjectClient<Inventory>
    {
        public InventoryClient(ApiClient client) : base(client) { }

        public override string Resource
        {
            get
            {
                return "inventory/items/";
            }
        }
    }
}
