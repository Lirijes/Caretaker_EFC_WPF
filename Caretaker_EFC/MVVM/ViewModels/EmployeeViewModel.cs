using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class EmployeeViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        public EmployeeViewModel()
        {
            CurrentViewModel = new ListEmployeesViewModel();
        }

        [RelayCommand]
        public void GoToAddEmployee()
        {
            CurrentViewModel = new AddEmployeeViewModel();
        }

        [RelayCommand]
        public void GoToEmployeeList()
        {
            CurrentViewModel = new AllListsViewModel();
        }

        [RelayCommand]
        public void GoToSpecEmployee()
        {
            CurrentViewModel = new SpecEmployeeViewModel();
        }
    }
}
