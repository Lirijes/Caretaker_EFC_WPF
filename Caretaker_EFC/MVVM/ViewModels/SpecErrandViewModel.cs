using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.MVVM.Models.Entities;
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
        private ObservableCollection<CommentEntity>? allComments;

        [ObservableProperty]
        private ObservableCollection<Status>? statuses;

        [ObservableProperty]
        public string streetname = string.Empty;

        [ObservableProperty]
        public Errand selectedErrand = new Errand();

        [ObservableProperty]
        public Status selectedStatus = null!;

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private int errandStatusId;

        public SpecErrandViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
            errandStatusId = SelectedErrand.StatusId;
        }

        public async Task LoadCasesAsync()
        {
            Errands = new ObservableCollection<Errand>(await ErrandService.GetAllErrandsAsync());

            foreach (Errand errand in Errands)
            {
                AllComments = new ObservableCollection<CommentEntity>(await CommentService.GetAllCOmmentAsync(errand.OrderNumber));
                errand.Comments = AllComments;
            }
            Statuses = new ObservableCollection<Status>(await StatusService.GetAllStatusAsync());
        }

        [RelayCommand]
        public async Task GetStatus(Status selectedStatus)
        {
            await StatusService.GetStatusAsync(selectedStatus);
        }

        [RelayCommand]
        public async Task SaveSAsync()
        {
            if(SelectedErrand != null && SelectedStatus != null)
            {
                MessageBox.Show("Status updated.");
                await ErrandService.UpdateStatusErrandAsync(SelectedErrand.OrderNumber, SelectedStatus);
                Statuses = new ObservableCollection<Status>(await StatusService.GetAllStatusAsync());
            }
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

            MessageBox.Show("Comment is added.");
        }
    }
}
