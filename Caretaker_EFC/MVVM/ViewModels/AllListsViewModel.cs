using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class AllListsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "All Lists";

        [ObservableProperty]
        private ObservableCollection<Employee> employees = EmployeeService.Employees();

        [ObservableProperty]
        private ObservableCollection<Address> addresses = AddressService.Addresses();

        [ObservableProperty]
        private ObservableCollection<Errand> errands = ErrandService.Errands();
    }
}
