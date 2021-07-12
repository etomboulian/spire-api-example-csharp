using System;

namespace ApiTest
{
    using ApiTest.InventoryApi;
    using ApiTest.Client;
    using System.Diagnostics;
    using System.Collections.Generic;

    public class Program
    {
        static int Main(string[] args)
        {
            // Set some initial variables in order to connect to the Spire server
            const string hostname = "10.11.13.138";
            const int port = 10880;
            const string companyName = "inspire";
            const string username = "ApiUser";
            const string password = "Spire123!";
            
            // Initialize an API Client object
            ApiClient client = new ApiClient(hostname, port, companyName, username, password);

            // Initialize an API Client for Inventory Items from the APIClient object
            InventoryClient inventoryClient = new InventoryClient(client);

            // Initialize the Spire Test class containing an instance of inventoryClient and the testing methods to use
            SpireTests spireTests = new SpireTests(inventoryClient);
            
            try
            {
                // Create a new inventory item
                Inventory item = new Inventory();
                item.id = null;
                item.whse = "VA";
                item.partNo = "TESTPART-SPIRE";
                item.type = InventoryType.Normal;
                item.status = InventoryStatus.Active;
                item.description = "Test Inventory";
                item.uom = new List<UnitOfMeasure>();

                // Create a unit of measure for this new item
                UnitOfMeasure itemUom = new UnitOfMeasure();
                itemUom.description = "EA";

                // Add the unit of measure to the item properties
                item.uom.Add(itemUom);

                // Create the new item in Spire, and get a reference to the newly created item from Spire
                item = spireTests.CreateInventory(item);

                // Search Inventory items for a given string and print their part_no to the debug console
                spireTests.SearchInventory("TEST");

                // Get the id newly created item from Spire by its inventory id
                spireTests.GetInventoryItemById(item.id);

                // Update the newly created item from spire by its inventory id
                item.description = "Changed Description via API";
                spireTests.UpdateInventoryItemById(item.id, item);

                // Delete the newly created item from spire by its inventory id
                spireTests.DeleteInventoryItemById(item.id);
                
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