using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
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
        private ObservableCollection<Errand>? errands;

        [ObservableProperty]
        private ObservableCollection<Comment>? comments;

        [ObservableProperty]
        public Errand selectedErrand = null!;

        [ObservableProperty]
        private string description = string.Empty;

        public SpecErrandViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
        }

        public async Task LoadCasesAsync()
        {
            Errands = new ObservableCollection<Errand>(await ErrandService.GetAllErrandsAsync());
            Comments = new ObservableCollection<Comment>(await CommentService.GetAllCOmmentAsync());
        }

        [RelayCommand]
        public async Task EditStatusErrand()
        {
            MessageBox.Show($"Status changed on ordernumber: {SelectedErrand.OrderNumber}.");
            await UpdateStatusErrand(SelectedErrand.OrderNumber, SelectedErrand);
        }
        public async Task UpdateStatusErrand(string ordernumber, Errand errand)
        {
            await ErrandService.UpdateStatusErrandAsync(ordernumber, errand);
        }

        [RelayCommand]
        public async Task SaveCommentAsync()
        {
            await CommentService.SaveCommentAsync(new Comment
            {
                Created = DateTime.Now,
                Description = Description,
                ErrandOrdernumber = SelectedErrand.OrderNumber
            });

            MessageBox.Show($"Comment is added.");
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
