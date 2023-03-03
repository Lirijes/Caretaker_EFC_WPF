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
    public partial class EmployeeViewModel : ObservableObject
    {

        /*[ObservableProperty]
        private ObservableObject employeeCurrentViewModel;

        [ObservableProperty]
        private ObservableObject listEmployeeViewModel;

        [ObservableProperty]
        private ObservableCollection<Employee> employees = EmployeeService.Employees();

        [ObservableProperty]
        private ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();

        public EmployeeViewModel()
        {
            EmployeeCurrentViewModel = new ListEmployeesViewModel();
            listEmployeeViewModel = new ListEmployeesViewModel();
        }


        // ADD EMPLOYEE

        [ObservableProperty]
        private string firstname = string.Empty;

        [ObservableProperty]
        private string lastname = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phonenumber = string.Empty;

        [RelayCommand]
        public async Task SaveAsync()
        {
            await EmployeeService.SaveEmployeeAsync(new Employee
            {
                FirstName = Firstname,
                LastName = Lastname,
                Email = Email,
                PhoneNumber = Phonenumber
            });

            Firstname = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            Phonenumber = string.Empty;
        }

        // LIST ALL EMPLOYEE


        // SHOW SPECIFIC EMPLOYEE

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


        // views

        [RelayCommand]
        public void GoToAddEmployee()
        {
            EmployeeCurrentViewModel = new AddEmployeeViewModel();
        }

        [RelayCommand]
        public void GoToEmployeeList()
        {
            EmployeeCurrentViewModel = new ListEmployeesViewModel();
        }

        [RelayCommand]
        public void GoToSpecEmployee()
        {
            EmployeeCurrentViewModel = new SpecEmployeeViewModel();
        }*/



    }
}
