using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class ListEmployeesViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "All Employees";

        [ObservableProperty]
        private ObservableCollection<Employee> employees = EmployeeService.Employees();
    }
}
