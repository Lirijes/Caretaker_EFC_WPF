using Caretaker_EFC.MVVM.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        public MainViewModel()
        {
            CurrentViewModel= this;
        }

        [RelayCommand]
        public void GoToEmployees()
        {
            CurrentViewModel = new EmployeeViewModel();
        }

        [RelayCommand]
        public void GoToErrands()
        {
            CurrentViewModel = new ErrandViewModel();
        }

        [RelayCommand]
        public void GoToAddress()
        {
            CurrentViewModel = new AddressViewModel();
        }
    }
}
