using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class AddressViewModel :ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        public AddressViewModel()
        {
            CurrentViewModel = new AddAddressViewModel();
        }


        [RelayCommand]
        public void GoToAddAddress()
        {
            CurrentViewModel = new AddAddressViewModel();
        }

        [RelayCommand]
        public void GoToAddressList()
        {
            CurrentViewModel = new AllListsViewModel();
        }

        [RelayCommand]
        public void GoToSpecAddress()
        {
            CurrentViewModel = new SpecAddressViewModel();
        }
    }
}
