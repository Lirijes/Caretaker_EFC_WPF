using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class AllListsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "All Lists";

        [ObservableProperty]
        private ObservableCollection<Employee>? employees;

        [ObservableProperty]
        private ObservableCollection<Errand>? errands;

        [ObservableProperty]
        private ObservableCollection<Address>? addresses;

        public AllListsViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
        }

        public async Task LoadCasesAsync()
        {
            Addresses = new ObservableCollection<Address>(await AddressService.GetAllAddressesAsync());
            Employees = new ObservableCollection<Employee>(await EmployeeService.GetAllEmployeeAsync());
            Errands = new ObservableCollection<Errand>(await ErrandService.GetAllErrandsAsync());
        }

        [ObservableProperty]
        public Errand selectedErrand = null!;

        [ObservableProperty]
        public Employee selectedEmployee = null!;

        [ObservableProperty]
        public Address selectedAddress = null!;

        [RelayCommand]
        public async Task RemoveAddress()
        {
            MessageBox.Show($"Are you sure that you want to remove: {SelectedAddress.StreetName}?");
            //await AddressService.RemoveAddressAsync(selectedAddress);
        }

        [RelayCommand]
        public async Task RemoveEmployee(Employee selectedEmployee)
        {
            MessageBox.Show($"Are you sure that you want to remove: {SelectedEmployee.FirstName} {SelectedEmployee.LastName}?");
           // await EmployeeService.RemoveEmployeeAsync(selectedEmployee);
        }

        [RelayCommand]
        public async Task RemoveErrand(string selectedErrand)
        {
            MessageBox.Show($"Are you sure that you want to remove {SelectedErrand.OrderNumber}");
            await ErrandService.RemoveErrandAsync(selectedErrand);
        }
    }
}
