using System.Collections.Generic;


namespace ApiTest.InventoryApi
{
    public class Inventory
    {
        public int? id { get; set; }
        public string partNo { get; set; }
        public string whse { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int status { get; set; }
        public decimal onHandQty { get; set; }
        public decimal committedQty { get; set; }
        public decimal backorderQty { get; set; }
        public List<UnitOfMeasure> uom { get; set; }
    }
}
