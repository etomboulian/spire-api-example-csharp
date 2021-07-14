using System;
using System.Collections.Generic;
using ApiTest.InventoryApi;
using ApiTest.Client;


namespace ApiTest
{
     class SpireTests 
    {  
        private InventoryClient InventoryClient {get; set;}

        public SpireTests(InventoryClient inventoryClient)
        {
            InventoryClient = inventoryClient;
        }

        public Inventory CreateInventory( Inventory inventory)
        {
            inventory = InventoryClient.Create(inventory);
            Console.WriteLine($"Created item - ID:{inventory.id} | partNo:{inventory.partNo}");
            Console.WriteLine();
            return inventory;
        }

        public void SearchInventory(string searchString)
        {
            Console.WriteLine("Search Results: ");
            // List inventory matching the query "TEST"
            foreach (var i in InventoryClient.List(0, 100, "TEST"))
            {
                Console.WriteLine(i.partNo);
            }
            Console.WriteLine();
        }

        public int? GetInventoryItemById(int? id)
        {
            if (id != null)
            {
                Inventory inventory = InventoryClient.Fetch(id);
                Console.WriteLine($"Getting item by ID: ({id}) | partNo:{inventory.partNo} | description:{inventory.description} | onHandQty: {inventory.onHandQty}");
                Console.WriteLine();
                return inventory.id;
            }
            else
            {
                throw new ArgumentNullException("id cannot be null");
            }
        }

        public void UpdateInventoryItemById(int? id, Inventory inventoryItem)
        {
            Console.WriteLine($"Updating inventory item - partNo: {inventoryItem.partNo} | description: {inventoryItem.description}");
            Console.WriteLine();
            if (id != null)
            {
                InventoryClient.Update(id, inventoryItem);
            }
            else
            {
                throw new ArgumentNullException("id cannot be null");
            }
        }

        public void DeleteInventoryItemById(int? id)
        {
            if(id != null)
            {
                InventoryClient.Delete(id);
            }
            else
            {
                throw new ArgumentNullException("id cannot be null");
            }
            Console.WriteLine($"Deleted item by ID: {id}");
        }
    }
}
