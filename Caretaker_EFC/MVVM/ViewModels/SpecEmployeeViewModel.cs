﻿using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class SpecEmployeeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Edit Contact";

        [ObservableProperty]
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        [ObservableProperty]
        public Employee selectedEmployee = null!;

        [RelayCommand]
        public async Task EditEmployee(string Id)//det som läggs in här kan användas på min vies som en commansparameter
        {
            MessageBox.Show($"Contact {SelectedEmployee.FirstName} {SelectedEmployee.LastName} is updated");
            await EmployeeService.UpdateEmployeeAsync(SelectedEmployee.Id, SelectedEmployee);
        }
    }
}
