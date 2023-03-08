using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.MVVM.Models.Entities;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class AllListsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "All Lists";

        [ObservableProperty]
        private ObservableCollection<EmployeeEntity> employees = new ObservableCollection<EmployeeEntity>();

        [ObservableProperty]
        private ObservableCollection<Address> addresses = AddressService.Addresses();

        [ObservableProperty]
        private ObservableCollection<Errand> errands = ErrandService.Errands();


        [RelayCommand]
        public async Task GetAllAddresses()
        {
            await AddressService.GetAllAddressesAsync();
        }
    }
}
