using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class ErrandViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        public ErrandViewModel()
        {
        }

        [RelayCommand]
        public void GoToAddErrand()
        {
            CurrentViewModel = new AddErrandViewModel();
        }

        [RelayCommand]
        public void GoToErrandList()
        {
            CurrentViewModel = new AllListsViewModel();
        }

        [RelayCommand]
        public void GoToSpecErrand()
        {
            CurrentViewModel = new SpecErrandViewModel();
        }
    }
}
