using Caretaker_EFC.MVVM.ViewModels;
using System.Windows.Controls;

namespace Caretaker_EFC.MVVM.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();

            //hur får jag till det så man kan gå till alla dessa olika sidor från employeeview?
            //och att gå hit från mainwindow?

            //new AddEmployeeViewModel();
            //new ListEmployeesViewModel();
            //new SpecEmployeeViewModel();
        }
    }
}
