using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class AddAddressViewModel : ObservableObject
    {
        public AddAddressViewModel()
        {
        }

        [ObservableProperty]
        private string pageTitle = "Add Address";

        [ObservableProperty]
        private string streetname = string.Empty;

        [ObservableProperty]
        private string city = string.Empty;

        [ObservableProperty]
        private string postalcode = string.Empty;

        [RelayCommand]
        public async Task SaveAddressAsync()
        {
            await AddressService.SaveAddressAsync(new Address
            {
                StreetName = Streetname,
                City = City,
                PostalCode = Postalcode
            });

            Streetname = string.Empty;
            City = string.Empty;
            Postalcode = string.Empty;

            MessageBox.Show($"Address {Streetname} is added.");
        }

        [ObservableProperty]
        private ObservableCollection<Address> addresses = AddressService.Addresses();
    }
}
