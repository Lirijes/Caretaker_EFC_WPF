using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.MVVM.Models.Entities;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class AllListsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "All Lists";

        [ObservableProperty]
        private ObservableCollection<Employee>? employees;

        [ObservableProperty]
        private ObservableCollection<Errand>? errands;

        [ObservableProperty]
        private ObservableCollection<Address>? addresses;

        [ObservableProperty]
        private ObservableCollection<Comment>? comments;

        public AllListsViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
        }

        public async Task LoadCasesAsync()
        {
            Addresses = new ObservableCollection<Address>(await AddressService.GetAllAddressesAsync());
            Employees = new ObservableCollection<Employee>(await EmployeeService.GetAllEmployeeAsync());
            Errands = new ObservableCollection<Errand>(await ErrandService.GetAllErrandsAsync());
            foreach (Errand errand in Errands)
            {
                errand.Comments = new ObservableCollection<CommentEntity>(await CommentService.GetAllCOmmentAsync(errand.OrderNumber));
            }
        }
    }
}
