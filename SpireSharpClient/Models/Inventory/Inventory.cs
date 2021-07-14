using System.Collections.Generic;

namespace ApiTest.InventoryApi
{
    public class Inventory
    {
        public int? id { get; set; }
        public string whse { get; set; }
        public string partNo { get; set; }
        public string description { get; set; }
        public int status { get; set; }
        public int availableQty { get; set; }
        public decimal onHandQty { get; set; }
        public decimal backorderQty { get; set; }
        public decimal committedQty { get; set; }
        public decimal onPurchaseQty { get; set; }
        public string buyMeasureCode { get; set; }
        // stockMeasureCode - Cannot be null if included
        public string stockMeasureCode { get; set; }
        public string sellMeasureCode { get; set; }
        public string alternatePartNo { get; set; }
        public decimal currentCost { get; set; }
        public decimal averageCost { get; set; }
        public string type { get; set; }
        public List<UnitOfMeasure> uom { get; set; }
    }
}
