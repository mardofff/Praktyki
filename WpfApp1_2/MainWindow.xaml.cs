using System.Windows;

namespace TaxCalculatorApp
{
    public partial class MainWindow : Window
    {
        private decimal stawkaPodatkowa = 0.12m; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtBrutto.Text, out decimal brutto) && brutto > 0)
            {
                decimal netto = brutto - brutto * stawkaPodatkowa;

                listBrutto.Items.Add(brutto.ToString("C"));
                listNetto.Items.Add(netto.ToString("C"));

                txtBrutto.Clear();
            }
            else
            {
                MessageBox.Show("Wprowadź poprawną wartość pensji brutto.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
           
            if (radioButton8_5.IsChecked == true)
                stawkaPodatkowa = 0.085m;
            else if (radioButton12.IsChecked == true)
                stawkaPodatkowa = 0.12m;
            else if (radioButton19.IsChecked == true)
                stawkaPodatkowa = 0.19m;
        }
    }
}
