using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.MVVM.Models.Entities;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Caretaker_EFC.MVVM.ViewModels.Employee
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
        public static async Task SaveEmployeeAsync()
        {
            //var employee = new EmployeeEntity();
            //how to call on saveemployeeasync??
            await EmployeeService.SaveEmployeeAsync(new EmployeeEntity { FirstName = firstname });
            firstname = string.Empty;

        }
    }
}
