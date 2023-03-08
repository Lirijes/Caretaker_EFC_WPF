using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class ListErrandsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "All Errands";

        /*[ObservableProperty]
        private ObservableCollection<Errand>? errands;

        public ListErrandsViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
        }

        public async Task LoadCasesAsync()
        {
            Errands = new ObservableCollection<Errand>(await ErrandService.GetAllErrandsAsync());
        }*/
    }
}
