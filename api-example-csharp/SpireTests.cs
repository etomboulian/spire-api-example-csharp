using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiTest.InventoryApi;
using ApiTest.Client;
using System.Diagnostics;

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
            return inventory;
        }

        public void SearchInventory(string searchString)
        {
            // List inventory matching the query "TEST"
            foreach (var i in InventoryClient.List(0, 100, "TEST"))
            {
                Debug.WriteLine(i.partNo);
            }
        }

        public int? GetInventoryItemById(int? id)
        {
            if (id != null)
            {
                Inventory inventory = InventoryClient.Fetch(id);
                Debug.WriteLine($"{inventory.partNo} {inventory.onHandQty}");
                return inventory.id;
            }
            else
            {
                throw new ArgumentNullException("id cannot be null");
            }
        }

        public void UpdateInventoryItemById(int? id, Inventory inventoryItem)
        {
            if(id != null)
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
        }
    }
}
