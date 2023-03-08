using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class AddEmployeeViewModel : ObservableObject
    {
        public AddEmployeeViewModel()
        {
        }

        [ObservableProperty]
        private string pageTitle = "Add Employee";

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

            MessageBox.Show($"Employee {Firstname} is added.");
        }

        [ObservableProperty]
        private ObservableCollection<Employee> employees = EmployeeService.Employees();
    }
}
