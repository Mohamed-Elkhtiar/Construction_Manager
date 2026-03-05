using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionMaterialManager.Modle
{
    public static class AppData
    {
        public static ObservableCollection<Material> Materials { get; set; } = new ObservableCollection<Material>
            {
                new Material { Name = "Cement", Category = "Concrete", Unit = "Bag", UnitPrice = 5.00m },
                new Material { Name = "P", Category = "Paint", Unit = "Bag", UnitPrice = 5.00m },
                new Material { Name = "T", Category = "Tiles", Unit = "Bag", UnitPrice = 5.00m },
                new Material { Name = "Steel", Category = "Steel", Unit = "Ton", UnitPrice = 500.00m },
                new Material { Name = "Bricks", Category = "General", Unit = "Piece", UnitPrice = 0.50m }
            };
        public static ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>
        
            {
                new Order { OrderNumber = 1, MaterialName = "Cement", Category = "Concrete", Quantity = 100, Unit = "Bag", UnitPrice = 5.00m, Total = 500.00m, Date = DateTime.Now, Status = "Pending" },
                new Order { OrderNumber = 2, MaterialName = "Steel", Category = "Steel", Quantity = 10, Unit = "Ton", UnitPrice = 500.00m, Total = 5000.00m, Date = DateTime.Now, Status = "Delivered" },
                new Order { OrderNumber = 3, MaterialName = "Bricks", Category = "Paint", Quantity = 1000, Unit = "Piece", UnitPrice = 0.50m, Total = 500.00m, Date = DateTime.Now, Status = "Pending" },
                new Order { OrderNumber = 4, MaterialName = "Tiles", Category = "Tiles", Quantity = 200, Unit = "m²", UnitPrice = 10.00m, Total = 2000.00m, Date = DateTime.Now, Status = "Delivered" },
                new Order { OrderNumber = 5, MaterialName = "Paint", Category = "Paint", Quantity = 50, Unit = "Liter", UnitPrice = 20.00m, Total = 1000.00m, Date = DateTime.Now, Status = "Pending" }
            
        };
    }
}
