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
        public async Task EditStatusErrand()
        {
            MessageBox.Show($"Status changed on ordernumber: {SelectedErrand.OrderNumber}.");
            await ErrandService.UpdateStatusErrandAsync(SelectedErrand.OrderNumber, SelectedErrand);
        }
        public async Task UpdateStatusErrand(string ordernumber, Errand errand)
        {
            await ErrandService.UpdateStatusErrandAsync(ordernumber, errand);
        }

        [RelayCommand]
        public async Task AddComment(Comment comment)
        {
            MessageBox.Show($"Comment added to {SelectedErrand.OrderNumber}.");
            await ErrandService.SaveCommentAsync(SelectedErrand.OrderNumber, comment);
        }
        public async Task UpdateCommentErrand(string ordernumber, Comment comment)
        {
            MessageBox.Show($"Comment added to {SelectedErrand.OrderNumber}.");
            await ErrandService.SaveCommentAsync(ordernumber, comment);
        }

        [RelayCommand]
        public async Task EditErrand()
        {
            MessageBox.Show($"Errand with ordernumber {SelectedErrand.OrderNumber} is updated ");
            //await ErrandService.UpdateErrandAsync(SelectedErrand.OrderNumber, SelectedErrand);
        }

        public async Task UpdateErrand(string ordernumber, Errand errand)
        {
            //inte nödvändiga atm
            //await ErrandService.UpdateErrandAsync(ordernumber, errand);
        }

        [RelayCommand]
        public async Task Remove(string selectedErrand)
        {
            MessageBox.Show($"Are you sure that you want to remove {SelectedErrand.OrderNumber}");
            await ErrandService.RemoveErrandAsync(selectedErrand);
        }


    }
}
