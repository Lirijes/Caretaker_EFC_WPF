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
            CurrentViewModel = new ListErrandsViewModel();
        }

        [RelayCommand]
        public void GoToAddTask()
        {
            CurrentViewModel = new AddErrandViewModel();
        }

        [RelayCommand]
        public void GoToTaskList()
        {
            CurrentViewModel = new ListErrandsViewModel();
        }

        [RelayCommand]
        public void GoToSpecTask()
        {
            CurrentViewModel = new SpecErrandViewModel();
        }
    }
}
