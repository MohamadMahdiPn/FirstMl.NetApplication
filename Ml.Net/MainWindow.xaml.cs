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
using Ml_Net;

namespace Ml.Net
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

        private void sldSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
                lblGhz.Content = $"{sldSpeed.Value:F1} GHz";
        }

        private void sldRAM_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
                lblRAMGb.Content = $"{sldRAM.Value:####} Gb";
        }

        private void sldScreenSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
                lblScreenSize.Content = $"{sldScreenSize.Value:F1}\"";
        }

        private void sldStorage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
                lblStorageGb.Content = $"{sldStorage.Value:####} Gb";
        }

        private void sldWeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
                lblWeightPounds.Content = $"{sldWeight.Value:F1}";
        }

        private void btnPredictPrice_Click(object sender, RoutedEventArgs e)
        {
            var predictedPrice = PredictPrice(cboCPU1.Text, sldSpeed.Value, cboGPU.Text, cboRAMType.Text, sldRAM.Value,
                sldScreenSize.Value, sldStorage.Value, chkIsSSD.IsChecked.Value, sldWeight.Value);

            lblPrice.Content = $"{predictedPrice}";
        }

        private float PredictPrice(string CPU,
            double GHz,
            string GPU,
            string RAMType,
            double RAMAmount,
            double screenSize,
            double storage,
            bool isSSD,
            double weight)
        {
            
            MLModelLaptopPrice.ModelInput input = new MLModelLaptopPrice.ModelInput()
            {
                CPU = CPU,
                GHz = (float)GHz,
                GPU = GPU,
                RAMType = RAMType,
                RAM = (float)RAMAmount,
                Screen = (float)screenSize,
                Storage = (float)storage,
                SSD = isSSD,
                Weight = (float)weight
            };
            MLModelLaptopPrice.ModelOutput result = MLModelLaptopPrice.Predict(input);
            return result.Score;

        }
    }
}