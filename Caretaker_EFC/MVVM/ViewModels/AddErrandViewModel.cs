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
    public partial class AddErrandViewModel : ObservableObject
    {
        public AddErrandViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
        }

        [ObservableProperty]
        private string pageTitle = "Add Errand";

        [ObservableProperty]
        private string ordernumber = string.Empty;

        [ObservableProperty]
        private string customername = string.Empty;

        [ObservableProperty]
        private string customeremail = string.Empty;

        [ObservableProperty]
        private string customerphonenumber = string.Empty;

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private ObservableCollection<Address>? addresses;

        [ObservableProperty]
        public Address selectedAddress = null!;

        public async Task LoadCasesAsync()
        {
            Addresses = new ObservableCollection<Address>(await AddressService.GetAllAddressesAsync());
        }
        
        //hjälp hur ska jag markera en selected address så den sparas till ärendet?
        [RelayCommand]
        public async Task GetAddress(Address selectedAddress)
        {
            await AddressService.GetAddressAsync(selectedAddress);
        }

        [RelayCommand]
        public async Task SaveErrandAsync()
        {
            await ErrandService.SaveErrandAsync(new Errand
            {
                OrderNumber = Ordernumber,
                OrderDate = DateTime.Now,
                CustomerName = Customername,
                CustomerEmail= Customeremail,
                CustomerPhoneNumber = Customerphonenumber,
                Description = Description
            });

            Ordernumber = string.Empty;
            Customername = string.Empty;
            Customeremail = string.Empty;
            Customerphonenumber = string.Empty;
            Description = string.Empty;

            MessageBox.Show($"Errand {Ordernumber} is added.");
        }
    }
}
