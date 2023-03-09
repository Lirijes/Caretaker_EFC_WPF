using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Caretaker_EFC.MVVM.Views
{
    /// <summary>
    /// Interaction logic for SpecEmployeeView.xaml
    /// </summary>
    public partial class SpecEmployeeView : UserControl
    {
        public SpecEmployeeView()
        {
            InitializeComponent();
        }

        public void btn_removeEmployee_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var employee = (Employee)button.DataContext;

            Task.Run(async () => await EmployeeService.RemoveEmployeeAsync(employee.Email));
            MessageBox.Show("Employee is removed, please update the page.");
        }
    }
}
