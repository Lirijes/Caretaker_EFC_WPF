using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Caretaker_EFC.MVVM.Views
{
    /// <summary>
    /// Interaction logic for SpecAddressView.xaml
    /// </summary>
    public partial class SpecAddressView : UserControl
    {
        public SpecAddressView()
        {
            InitializeComponent();
        }

        private void btn_removeAdress_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var address = (Address)button.DataContext;

            Task.Run(async () => await AddressService.RemoveAddressAsync(address.Id));
            MessageBox.Show("Address is removed, please update the page.");
        }
    }
}
