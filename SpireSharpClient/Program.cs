using System;

namespace ApiTest
{
    using ApiTest.InventoryApi;
    using ApiTest.Client;
    using System.Collections.Generic;
    using api_example_csharp.SalesOrder;

    public class Program
    {
        static int Main(string[] args)
        {
            ApiClient client = new ApiClient();

            // Initialize an API Client for Sales Orders from the APIClient object
            SalesOrderClient salesOrderClient = new SalesOrderClient(client);

            SalesOrder order = new SalesOrder
            {
                customer = new Customer
                {
                    customerNo = "ABOX"
                },
                status = "O",
                type = "O",
                hold = false,
                orderDate = DateTime.Now,
                requiredDate = (DateTime.Now.AddDays(7)),
                customerPO = "TEST-PO"
            };

            salesOrderClient.Create(order);

            return 0;
        }

    }
}