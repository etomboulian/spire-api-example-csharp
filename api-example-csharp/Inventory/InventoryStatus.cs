using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest.InventoryApi
{
    public sealed class InventoryStatus
    {
        public static int Active = 0;
        public static int OnHold = 1;
        public static int Inactive = 2;
    }
}
