using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Caretaker_EFC.MVVM.Views
{
    /// <summary>
    /// Interaction logic for SpecErrandView.xaml
    /// </summary>
    public partial class SpecErrandView : UserControl
    {
        public SpecErrandView()
        {
            InitializeComponent();
        }

        private void btn_removeErrand_Click_1(object sender, RoutedEventArgs e)
        {

            var button = (Button)sender;
            var errand = (Errand)button.DataContext;

            Task.Run(async () => await ErrandService.RemoveErrandAsync(errand.OrderNumber));
            MessageBox.Show("Errand is removed, please update the page.");
        }
    }
}
