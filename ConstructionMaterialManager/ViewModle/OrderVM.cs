using ConstructionMaterialManager.Modle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionMaterialManager.Command;

namespace ConstructionMaterialManager.ViewModle
{
    public class OrderVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<string> CategoriesFilter { get; } = new List<string> { "All","Concrete", "Steel", "Paint", "Tiles", "General" };
        public List<string> StatusOptions { get; } = new List<string> { "All", "Pending", "Delivered" };
        //filters
        private string _FilterOrderByName;
        public string FilterOrderByName
        {
            get { return _FilterOrderByName; }
            set
            {
                if (_FilterOrderByName != value)
                {
                    _FilterOrderByName = value;
                    OnPropertyChanged(nameof(FilterOrderByName));
                    ApplyFilters();
                }
            }
        }
        private string _SelectedCategory;
        public string SelectedCategory
        {
            get { return _SelectedCategory; }
            set
            {
                if (_SelectedCategory != value)
                {
                    _SelectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                    ApplyFilters();
                }
            }
        }
        private string _SelectedStatus;
        public string SelectedStatus
        {
            get { return _SelectedStatus; }
            set
            {
                if (_SelectedStatus != value)
                {
                    _SelectedStatus = value;
                    OnPropertyChanged(nameof(SelectedStatus));
                    ApplyFilters();
                }
            }
        }
        private DateTime? _StartDate =null;
        public DateTime? StartDate
        {
            get { return _StartDate; }
            set
            {
                if (_StartDate != value)
                {
                    _StartDate = value;
                    OnPropertyChanged(nameof(StartDate));
                    ApplyFilters();
                }
            }
        }
        private DateTime?    _EndDate =null;
        public DateTime? EndDate
        {
            get { return _EndDate; }
            set
            {
                if (_EndDate != value)
                {
                    _EndDate = value;
                    OnPropertyChanged(nameof(EndDate));
                    ApplyFilters();
                }
            }
        }
        public void ApplyFilters()
        {
            var filteredOrders = Orders.Where(o => (string.IsNullOrEmpty(FilterOrderByName) ||
                o.MaterialName.StartsWith(FilterOrderByName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(SelectedCategory) || SelectedCategory == "All" || o.Category == SelectedCategory) &&
                (string.IsNullOrEmpty(SelectedStatus) || SelectedStatus == "All" || o.Status == SelectedStatus) &&
                (StartDate == default || o.Date >= StartDate) &&
                (EndDate == default || o.Date <= EndDate));
            CurrentViewedOrders = new ObservableCollection<Order>(filteredOrders);
            OnPropertyChanged(nameof(TotalEGP));
                OnPropertyChanged(nameof(PendingOrdersCount));
        }

        private ObservableCollection<Order> _CurrentViewedOrders ;
           
        public ObservableCollection<Order> CurrentViewedOrders
        {
            get { return _CurrentViewedOrders; }
            set
            {
                _CurrentViewedOrders = value;
                OnPropertyChanged(nameof(CurrentViewedOrders));
            }
        }

        public decimal TotalEGP
        {
            get
            {
                if (CurrentViewedOrders == null)
                    return 0;

                return CurrentViewedOrders.Sum(a => a.Total);
            }
        }
        public int PendingOrdersCount
        {
            get
            {
                if (CurrentViewedOrders == null)
                    return 0;
                return CurrentViewedOrders.Count(o => o.Status == "Pending");
            }
        }

        private ObservableCollection<Order> _Orders = new ObservableCollection<Order>
            {
                new Order { OrderNumber = 1, MaterialName = "Cement", Category = "Concrete", Quantity = 100, Unit = "Bag", UnitPrice = 5.00m, Total = 500.00m, Date = DateTime.Now, Status = "Pending" },
                new Order { OrderNumber = 2, MaterialName = "Steel", Category = "Steel", Quantity = 10, Unit = "Ton", UnitPrice = 500.00m, Total = 5000.00m, Date = DateTime.Now, Status = "Delivered" },
                new Order { OrderNumber = 3, MaterialName = "Bricks", Category = "Paint", Quantity = 1000, Unit = "Piece", UnitPrice = 0.50m, Total = 500.00m, Date = DateTime.Now, Status = "Pending" },
                new Order { OrderNumber = 4, MaterialName = "Tiles", Category = "Tiles", Quantity = 200, Unit = "m²", UnitPrice = 10.00m, Total = 2000.00m, Date = DateTime.Now, Status = "Delivered" },
                new Order { OrderNumber = 5, MaterialName = "Paint", Category = "Paint", Quantity = 50, Unit = "Liter", UnitPrice = 20.00m, Total = 1000.00m, Date = DateTime.Now, Status = "Pending" }
            };

        public ObservableCollection<Order> Orders
        {
            get { return _Orders; }
            set
            {
                _Orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }


        private Order _SelectedOrder = new Order();

                    
        public Order SelectedOrder
        {
            get { return _SelectedOrder; }
            set { _SelectedOrder = value; }
        }

        public MyCommand MarkedDeliverd { get; set; }



        public OrderVM()
        {
            CurrentViewedOrders = new ObservableCollection<Order>(Orders);
            MarkedDeliverd = new MyCommand(
                execute: (param) =>
                {
                    if (SelectedOrder != null && SelectedOrder.Status == "Pending")
                    {
                        SelectedOrder.Status = "Delivered";
                        ApplyFilters();
                    }
                },
                canExecute: (param) => SelectedOrder != null && SelectedOrder.Status == "Pending"
            );
        }

    }
}
