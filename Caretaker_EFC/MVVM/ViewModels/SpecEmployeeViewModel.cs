using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class SpecEmployeeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Edit Employee";

        [ObservableProperty]
        private ObservableCollection<Employee>? employees;

        [ObservableProperty]
        public Employee selectedEmployee = null!;

        public SpecEmployeeViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
        }

        public async Task LoadCasesAsync()
        {
            Employees = new ObservableCollection<Employee>(await EmployeeService.GetAllEmployeeAsync());
        }

        [RelayCommand]
        public async Task EditEmployee()
        {
            MessageBox.Show($"Contact {SelectedEmployee.FirstName} {SelectedEmployee.LastName} is updated");
            await UpdateEmpolyee(SelectedEmployee.Id, SelectedEmployee);
        }
        public async Task UpdateEmpolyee(Guid id, Employee employee)
        {
            await EmployeeService.UpdateEmployeeAsync(id, employee);
        }
    }
}
