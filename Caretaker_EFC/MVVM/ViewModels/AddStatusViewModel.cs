using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class AddStatusViewModel : ObservableObject
    {
        public AddStatusViewModel()
        {
        }

        [ObservableProperty]
        private string pageTitle = "Add Status";

        [ObservableProperty]
        private string statusname = string.Empty;


        [RelayCommand]
        public async Task SaveStatusAsync()
        {
            await StatusService.SaveStatusAsync(new Status
            {
                StatusName = Statusname
            });

            Statusname = string.Empty;

            MessageBox.Show($"Status {Statusname} added.");
        }
    }
}
