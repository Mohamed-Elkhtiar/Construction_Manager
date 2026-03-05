using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionMaterialManager.Modle
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string MaterialName { get; set; }
        public string Category { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }       // Quantity * UnitPrice 
        public DateTime Date { get; set; }
        public string Status { get; set; }       // Pending or Delivered 
    }
}
