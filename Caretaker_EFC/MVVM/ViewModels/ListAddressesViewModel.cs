using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class ListAddressesViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "All Addresses";

        [ObservableProperty]
        private ObservableCollection<Address> addresses = AddressService.Addresses();

        [RelayCommand]
        public async Task GetAllAddresses()
        {
            await AddressService.GetAllAddressesAsync();
        }
    }
}
