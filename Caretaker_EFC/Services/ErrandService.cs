using Caretaker_EFC.Contexts;
using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Caretaker_EFC.Services
{
    internal class ErrandService
    {
        private static DataContext _context = new DataContext();

        public static ObservableCollection<Errand> errands = new ObservableCollection<Errand>();

        public static async Task SaveErrandAsync(Errand errand)
        {
            //här behöver vi vara en viss address för att kunna lägga in ett nytt ärende
            //vet ej om nedan fungerar 

            var address = AddressService.GetAddressAsync(errand.AddressId);

            if(address != null)
            {
                var errandEntity = new ErrandEntity();
                {
                    OrderNumber = errand.OrderNumber;
                    OrderDate = errand.OrderDate;
                    CustomerName = errand.CustomerName;
                    CustomerEmail = errand.CustomerEmail;
                    CustomerPhoneNumber = errand.CustomerPhoneNumber;
                    Description = errand.Description;
                    Status = errand.Status;
                }

                _context.Add(errandEntity);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task<IEnumerable<Errand>> GetAllErrandsAsync()
        {
            var _errands = new List<Errand>();

            foreach (var _errand in await _context.Errands.ToListAsync())
                _errands.Add(new Errand
                {
                    OrderNumber = _errand.OrderNumber,
                    OrderDate = _errand.OrderDate,
                    CustomerName = _errand.CustomerName,
                    CustomerEmail = _errand.CustomerEmail,
                    CustomerPhoneNumber = _errand.CustomerPhoneNumber,
                    Description = _errand.Description,
                    Status = _errand.Status
                });

            return _errands;
        }
    }
}
