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
            ElementTypeComboBox.ItemsSource = new string[] { "Foundation", "Column", "Beam", "Slap", "Footing" };
            cmbBarDiameter.ItemsSource = new List<string> { "8mm", "10mm", "12mm", "16mm", "20mm", "25mm", "32mm" };
            cmbSurfaceType.ItemsSource = new List<string> { "Interior Wall", "Exterior Wall", "Ceiling" };

            cmbBarDiameter.SelectedIndex = 2;
            ElementTypeComboBox.SelectedIndex = 0;
            cmbSurfaceType.SelectedIndex = 0;
        }


        public decimal Volume { get; set; }

        

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

        private void Btn_CalculateSteel(object sender, RoutedEventArgs e)
        {
            
            if (!decimal.TryParse(txtBarLength.Text, out decimal barlength) || barlength < 0)
            { 
                MessageBox.Show("Please enter a valid numeric value for bar length");
                return;
            }

            if (!int.TryParse(txtNumberOfBars.Text, out int numberOfBars) || numberOfBars < 0)
                {
                    MessageBox.Show("Please enter a valid numeric value for number of bars.");
                    return;
            }

                if (cmbBarDiameter.SelectedItem != null)
                {
                    string selectedDiameter = cmbBarDiameter.SelectedItem as string;
                    decimal diameterValue = decimal.Parse(selectedDiameter.Replace("mm", ""));
                    decimal weightPerBar = ((diameterValue * diameterValue) / 162) * barlength;
                    decimal totalWeight = weightPerBar * numberOfBars;
                    tbWeightPerBar.Text = weightPerBar.ToString("F3") + " kg";
                    tbTotalWeight.Text = (totalWeight / 1000).ToString("F3") + " Tons";
                    tbWeightWithWaste.Text = (totalWeight * 1.05m / 1000).ToString("F3") + " Tons";
                }
                else
                {
                    MessageBox.Show("Please select a bar diameter.");
                return;
                }
            }

        public void ClearOutput()
        {
            if (tbWeightPerBar == null || tbTotalWeight == null || tbWeightWithWaste == null)
                return;
            tbWeightPerBar.Text = string.Empty;
            tbTotalWeight.Text = string.Empty;
            tbWeightWithWaste.Text = string.Empty;
        }
        private void cmbBarDiameter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearOutput();
        }

        private void txtBarLength_TextChanged(object sender, TextChangedEventArgs e)
        {
                        ClearOutput();
        }

        private void txtNumberOfBars_TextChanged(object sender, TextChangedEventArgs e)
        {
                        ClearOutput();
        }

        private void rdSurfaceAreabyArea_Checked(object sender, RoutedEventArgs e)
        {
            if (pnlLengthWidth == null) return;
                        pnlLengthWidth.Visibility = Visibility.Collapsed;
                        pnlArea.Visibility = Visibility.Visible;
        }

        private void rdSurfaceAreabyLengthWidth_Checked(object sender, RoutedEventArgs e)
        {
            if (pnlArea == null) return;
                    pnlArea.Visibility = Visibility.Collapsed;
                                    pnlLengthWidth.Visibility = Visibility.Visible; 
        }

        private void Btn_CalculatePaint(object sender, RoutedEventArgs e)
        {
            decimal area = 0;
            int numbOfCoats;
            if (cmbSurfaceType.SelectedItem == null)
            {
                MessageBox.Show("Please select a surface type.");
                return;
            }
            if(cmbNumberOfCoats.SelectedItem == null)
            {
                MessageBox.Show("Please select a surface type.");
                return;
            }
            else
            {
                numbOfCoats = int.Parse(((ComboBoxItem)cmbNumberOfCoats.SelectedItem).Content.ToString());

            }
            if (rdSurfaceAreabyArea.IsChecked == true)
            {
                if (!decimal.TryParse(txtSurfaceArea.Text, out decimal byarea) || byarea < 0)
                {
                    MessageBox.Show("Please enter a valid numeric value for area.");
                    return;
                }
                area = byarea;
            }
            else
            {
                if (!decimal.TryParse(txtLength.Text, out decimal length) || length < 0)
                {
                    MessageBox.Show("Please enter a valid numeric value for length.");
                    return;
                }
                if (!decimal.TryParse(txtWidth.Text, out decimal width) || width < 0)
                {
                    MessageBox.Show("Please enter a valid numeric value for width.");
                    return;
                }
                area = length * width;

            }
            

            if (!decimal.TryParse(txtPaintCoverage.Text, out decimal coverage) || coverage <= 0)
            {
                MessageBox.Show("Please enter a valid numeric value for paint coverage.");
                return;
            }

            decimal paintRequired = area * numbOfCoats / coverage;

            tbResultLitres.Text = paintRequired.ToString("F2") + " Litres";
        }
    }
    }

