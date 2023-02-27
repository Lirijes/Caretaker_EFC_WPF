﻿using Caretaker_EFC.MVVM.ViewModels.Addresses;
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
        private ObservableObject listErrandsViewModel;

        public MainViewModel()
        {
            CurrentViewModel = new ListErrandsViewModel();
            ListErrandsViewModel = new ListErrandsViewModel();
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
            CurrentViewModel = new ListEmployeesViewModel();
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
            CurrentViewModel = new ListAddressesViewModel();
        }

        [RelayCommand]
        public void GoToSpecAddress()
        {
            CurrentViewModel = new SpecAddressViewModel();
        }

        #endregion

        #region errand

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

        #endregion
    }
}
