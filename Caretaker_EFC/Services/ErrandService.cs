﻿using Caretaker_EFC.Contexts;
using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Caretaker_EFC.Services
{
    public static class ErrandService
    {
        private static DataContext _context = new DataContext();

        public static ObservableCollection<Errand> errands = new ObservableCollection<Errand>();
        public static ObservableCollection<Comment> comments = new ObservableCollection<Comment>();

        public static async Task SaveErrandAsync(Errand errand)
        {
            {
                var errandEntity = new ErrandEntity
                {
                    OrderNumber = errand.OrderNumber,
                    OrderDate = errand.OrderDate,
                    CustomerName = errand.CustomerName,
                    CustomerEmail = errand.CustomerEmail,
                    CustomerPhoneNumber = errand.CustomerPhoneNumber,
                    Description = errand.Description,
                    Status = "Ej Påbörjad",
                    AddressId = errand.AddressId
                };

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

        public static async Task<Errand> GetErrandAsync(string ordernumber)
        {
            var _errand = await _context.Errands.FirstOrDefaultAsync(x => x.OrderNumber == ordernumber);
            if (_errand != null)
                return new Errand
                {
                    OrderNumber = _errand.OrderNumber,
                    OrderDate = _errand.OrderDate,
                    CustomerName = _errand.CustomerName,
                    CustomerEmail = _errand.CustomerEmail,
                    CustomerPhoneNumber = _errand.CustomerPhoneNumber,
                    Description = _errand.Description,
                    Status = _errand.Status
                };
            else
                return null!;
        }
        
        //public static async Task AddCommentToErrandAsync(string ordernumber, Errand errand)
        //{
        //    var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == errand.EmployeeId);
        //    var _errand = await _context.Errands.FirstOrDefaultAsync(x => x.OrderNumber == ordernumber);

        //    if (employee != null)
        //    {
        //        if(_errand != null)
        //        {
        //            var errandDesc = new Errand
        //            {
        //                Comment = errand.Comment
        //            };

        //            _context.Add(_errand);
        //            await _context.SaveChangesAsync();
        //        }
        //    }
        //}

        public static async Task UpdateStatusErrandAsync(string ordernumber, Errand errand)
        {
            var _errand = await _context.Errands.FirstOrDefaultAsync(x => x.OrderNumber == ordernumber);

            if(_errand != null) // om ärendet finns genom ordernummer gör följande
            {
                if(!string.IsNullOrEmpty(errand.Status))
                    _errand.Status = errand.Status;

                _context.Update(_errand);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task RemoveErrandAsync(string ordernumber)
        {
            var errand = await _context.Errands.FirstOrDefaultAsync(x => x.OrderNumber == ordernumber);
            if(errand != null)
            {
                _context.Remove(errand);
                await _context.SaveChangesAsync();
            }
        }

        public static ObservableCollection<Errand> Errands() 
        {
            var errandItems = new ObservableCollection<Errand>();
            foreach (Errand errand in errands)
                errandItems.Add(errand);
            return errandItems;
        }
    }
}
