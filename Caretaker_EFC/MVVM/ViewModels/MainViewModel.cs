using Caretaker_EFC.MVVM.ViewModels.Addresses;
using Caretaker_EFC.MVVM.ViewModels.Employee;
using Caretaker_EFC.MVVM.ViewModels.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        [ObservableProperty]
        private ObservableObject taskListViewModel;

        public MainViewModel()
        {
            CurrentViewModel = new TaskListViewModel();
            taskListViewModel = new TaskListViewModel();
        }

        #region employee

        [RelayCommand]
        public void GoToAddEmployee()
        {
            CurrentViewModel = new AddEmployeeViewModel();
        }

        [RelayCommand]
        public void GoToEmployeeList()
        {
            CurrentViewModel = new EmployeeListViewModel();
        }

        [RelayCommand]
        public void GoToSpecEmployee()
        {
            CurrentViewModel = new SpecEmployeeViewModel();
        }

        #endregion

        #region address

        [RelayCommand]
        public void GoToAddAddress()
        {
            CurrentViewModel = new AddAddressViewModel();
        }

        [RelayCommand]
        public void GoToAddressList()
        {
            CurrentViewModel = new AddressesListViewModel();
        }

        [RelayCommand]
        public void GoToSpecAddress()
        {
            CurrentViewModel = new SpecAddressViewModel();
        }

        #endregion

        #region task

        [RelayCommand]
        public void GoToAddTask()
        {
            CurrentViewModel = new AddTaskViewModel();
        }

        [RelayCommand]
        public void GoToTaskList()
        {
            CurrentViewModel = new TaskListViewModel();
        }

        [RelayCommand]
        public void GoToSpecTask()
        {
            CurrentViewModel = new SpecTaskViewModel();
        }

        #endregion
    }
}
