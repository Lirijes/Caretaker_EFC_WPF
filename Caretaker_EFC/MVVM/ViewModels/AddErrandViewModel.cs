using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Caretaker_EFC.MVVM.ViewModels
{
    public partial class AddErrandViewModel : ObservableObject
    {
        public AddErrandViewModel()
        {
        }

        [ObservableProperty]
        private string pageTitle = "Add Errand";

        [ObservableProperty]
        private string ordernumber = string.Empty;

        [ObservableProperty]
        private string customername = string.Empty;

        [ObservableProperty]
        private string customeremail = string.Empty;

        [ObservableProperty]
        private string customerphonenumber = string.Empty;

        [ObservableProperty]
        private string description = string.Empty;

        [RelayCommand]
        public async Task SaveErrandAsync()
        {

            //behöver att datum och ordernummer genereras automatiskt, hur?


            await ErrandService.SaveErrandAsync(new Errand
            {
                OrderNumber = Ordernumber,
                CustomerName = Customername,
                CustomerEmail= Customeremail,
                CustomerPhoneNumber = Customerphonenumber,
                Description = Description
            });

            Ordernumber = string.Empty;
            Customername = string.Empty;
            Customeremail = string.Empty;
            Customerphonenumber = string.Empty;
            Description = string.Empty;
        }

        [ObservableProperty]
        private ObservableCollection<Errand> errands = ErrandService.Errands();
    }
}
