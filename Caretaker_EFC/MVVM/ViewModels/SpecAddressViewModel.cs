using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class SpecAddressViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Edit Address";

        [ObservableProperty]
        private ObservableCollection<Address>? addresses;

        [ObservableProperty]
        public Address selectedAddress = null!;

        public SpecAddressViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
        }

        public async Task LoadCasesAsync()
        {
            Addresses = new ObservableCollection<Address>(await AddressService.GetAllAddressesAsync());
        }

        [RelayCommand]
        public async Task EditAddress()
        {
            MessageBox.Show($"Address {SelectedAddress.StreetName} {SelectedAddress.PostalCode} {SelectedAddress.City} is updated.");
            await UpdateAddress(SelectedAddress.Id, SelectedAddress);
        }
        public async Task UpdateAddress(int id, Address address)
        {
            await AddressService.UpdateAddressAsync(id, address);
        }
    }
}
