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
        private ObservableCollection<Status>? statuses;

        [ObservableProperty]
        public Address selectedAddress = null!;

        [ObservableProperty]
        public Status selectedStatus = null!;

        public async Task LoadCasesAsync()
        {
            Addresses = new ObservableCollection<Address>(await AddressService.GetAllAddressesAsync());
            Statuses = new ObservableCollection<Status>(await StatusService.GetAllStatusAsync());
        }
       
        [RelayCommand]
        public async Task GetAddress(Address selectedAddress)
        {
            await AddressService.GetAddressAsync(selectedAddress);
        }

        [RelayCommand]
        public async Task GetStatus(Status selectedStatus)
        {
            await StatusService.GetStatusAsync(selectedStatus);
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
                Description = Description,
                AddressId = SelectedAddress.Id,
                StatusId = SelectedStatus.Id
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
