using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Data;
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
        private ObservableCollection<Status>? statuses;

        [ObservableProperty]
        public Errand selectedErrand = null!;

        [ObservableProperty]
        public Status selectedStatus = null!;

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
            Statuses = new ObservableCollection<Status>(await StatusService.GetAllStatusAsync());
        }

        [RelayCommand]
        public async Task GetStatus(Status selectedStatus)
        {
            await StatusService.GetStatusAsync(selectedStatus);
        }

        [RelayCommand]
        public async Task SaveStatusAsync()
        {
            await UpdateStatusErrand(SelectedErrand.StatusId, SelectedStatus);
        }
        public async Task UpdateStatusErrand(int id, Status status)
        {
            await StatusService.UpdateStatusAsync(id, status);
        }

        [RelayCommand]
        public async Task SaveSEAsync()
        {
            await StatusService.SaveStatusAsync(new Status { Id = SelectedStatus.Id });
        }


        
        //ej fått till detta grafiskt än.
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
    }
}
