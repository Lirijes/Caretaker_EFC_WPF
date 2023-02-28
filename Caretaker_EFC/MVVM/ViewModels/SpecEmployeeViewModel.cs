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
        private string pageTitle = "Edit Contact";

        [ObservableProperty]
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        [ObservableProperty]
        public Employee selectedEmployee = null!;

        [RelayCommand]
        public async Task EditEmployee()//det som läggs in här kan användas på min vies som en commansparameter
        {
            MessageBox.Show($"Contact {SelectedEmployee.FirstName} {SelectedEmployee.LastName} is updated");
            await EmployeeService.UpdateEmployeeAsync(SelectedEmployee.Id, SelectedEmployee);
            //ändrat ovan selectedEmployee till stor bokstav då det var varning, kanske krånglar
        }
        public async Task Update(Guid id, Employee employee)
        {
            await EmployeeService.UpdateEmployeeAsync(id, employee);
        }

        //oklart om nedan fungerar med string selectedEmployee
        [RelayCommand]
        public async Task Remove(string selectedEmployee)
        {
            MessageBox.Show($"Are you sure that you want to remove: {SelectedEmployee.FirstName} {SelectedEmployee.LastName}?");
            await EmployeeService.RemoveEmployeeAsync(selectedEmployee);
        }

    }
}
