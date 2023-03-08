using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
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

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var ordernumber = (Errand)button.DataContext;

        }
    }
}
