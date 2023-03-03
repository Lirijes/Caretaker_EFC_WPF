using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class SpecErrandViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Edit Errand";

        [ObservableProperty]
        private ObservableCollection<Errand> errands = new ObservableCollection<Errand>();

        [ObservableProperty]
        public Errand selectedErrand = null!;

        [RelayCommand]
        public async Task EditCommentErrand()
        {
            MessageBox.Show($"Comment added to ordernumber {SelectedErrand.OrderNumber} updated.");
            await ErrandService.AddCommentToErrandAsync(SelectedErrand.OrderNumber, SelectedErrand);
        }
        public async Task UpdateCommentErrand(string ordernumber, Errand errand)
        {
            await ErrandService.AddCommentToErrandAsync(ordernumber, errand);
        }

        [RelayCommand]
        public async Task EditErrand()
        {
            MessageBox.Show($"Errand with ordernumber {SelectedErrand.OrderNumber} is updated ");
            await ErrandService.UpdateErrandAsync(SelectedErrand.OrderNumber, SelectedErrand);
        }

        public async Task UpdateErrand(string ordernumber, Errand errand)
        {
            await ErrandService.UpdateErrandAsync(ordernumber, errand);
        }

        [RelayCommand]
        public async Task Remove(string selectedErrand)
        {
            MessageBox.Show($"Are you sure that you want to remove {SelectedErrand.OrderNumber}");
            await ErrandService.RemoveErrandAsync(selectedErrand);
        }
    }
}
