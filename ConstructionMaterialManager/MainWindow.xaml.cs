using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConstructionMaterialManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_order_window(object sender, RoutedEventArgs e)
        {
            OrderWindow secondWindow = new OrderWindow();
            secondWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CalculatorWindow calculatorWindow = new CalculatorWindow();
            calculatorWindow.ShowDialog();
        }
    }       
    }
