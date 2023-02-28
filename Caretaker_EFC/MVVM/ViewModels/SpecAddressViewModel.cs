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
        private ObservableCollection<Address> addresses = new ObservableCollection<Address>();

        [ObservableProperty]
        public Address selectedAddress = null!;

        [RelayCommand]
        public async Task EditAddress()
        {
            MessageBox.Show($"Address {SelectedAddress.StreetName} {SelectedAddress.PostalCode} {SelectedAddress.City} is updated.");
            await AddressService.UpdateAddressAsync(SelectedAddress.Id, SelectedAddress);
        }
        public async Task UpdateAddress(int id, Address address)
        {
            await AddressService.UpdateAddressAsync(id, address);
        }

        [RelayCommand]
        public async Task RemoveAddress(int selectedAddress)
        {
            MessageBox.Show($"Are you sure that you want to remove: {SelectedAddress.StreetName}?");
            await AddressService.RemoveAddressAsync(selectedAddress);
        }
    }
}
