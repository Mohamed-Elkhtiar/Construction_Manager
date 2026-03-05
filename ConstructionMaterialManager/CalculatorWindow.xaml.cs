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
using System.Windows.Shapes;

namespace ConstructionMaterialManager
{
    /// <summary>
    /// Interaction logic for CalculatorWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {


        public CalculatorWindow()
        {
            InitializeComponent();
            DataContext = this;
            BarDiameterComboBox.ItemsSource = new List<string> { "8mm", "10mm", "12mm", "16mm", "20mm", "25mm", "32mm" };
            ElementTypeComboBox.ItemsSource = new string[] { "Foundation", "Column", "Beam", "Slap", "Footing" }; 

            BarDiameterComboBox.SelectedIndex = 2;
            ElementTypeComboBox.SelectedIndex = 0;
        }


        public decimal Volume { get; set; }

        private void ElementTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show($"Selected element type: {ElementTypeComboBox.SelectedItem as string}");
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(ElementLengthTextBox.Text, out decimal length) &&
                decimal.TryParse(ElementWidthTextBox.Text, out decimal width) &&
                decimal.TryParse(ElementDepthTextBox.Text, out decimal depth) &&
                int.TryParse(QuantityTextBox.Text, out int quantity))
            {
                Volume = length * width * depth * quantity;
                ResultVolumeTextBlock.Text = Volume.ToString("F2");
                ResultWithWasteValueTextBlock.Text = (Volume * 1.1m).ToString("F2");
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
        }
    }
}
