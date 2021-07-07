using System;

namespace ApiTest
{
    using ApiTest.InventoryApi;
    using ApiTest.Client;
    using System.Diagnostics;

    public class Program
    {
        static int Main(string[] args)
        {
            string hostname = "10.11.13.138";
            int port = 10880;
            string companyName = "inspire";
            string username = "ApiUser";
            string password = "Spire123!";
            

            var client = new ApiClient(hostname, port, companyName, username, password);
            var inventoryClient = new InventoryClient(client);

            try
            {
                // Create inventory
                var inventory = new Inventory();
                inventory.id = null;
                inventory.whse = "VA";
                inventory.partNo = "TESTPARTB";
                inventory.type = InventoryType.Normal;
                inventory.status = InventoryStatus.Active;
                inventory.description = "Test Inventory";
                inventory = inventoryClient.Create(inventory);

                // List inventory matching the query "TEST"
                foreach (var i in inventoryClient.List(0, 100, "TEST"))
                {
                    //Debug.WriteLine(i.partNo);
                }

                // Get inventory
                inventory = inventoryClient.Fetch(inventory.id);

                // Update inventory
                inventory.description = "New Description";
                inventoryClient.Update(inventory.id, inventory);

                // Delete inventory
                inventoryClient.Delete(inventory.id);
            }
            catch (ApiException e)
            {
                Console.Error.WriteLine(e.Message);
                return 1;
            }

            return 0;
        }
    }
}