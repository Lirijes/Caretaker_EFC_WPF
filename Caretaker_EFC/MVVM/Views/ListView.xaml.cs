using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
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

namespace Caretaker_EFC.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListView : UserControl
    {
        public ListView()
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
