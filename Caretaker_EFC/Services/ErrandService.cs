using Caretaker_EFC.Contexts;
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
            //här behöver vi vara en viss address för att kunna lägga in ett nytt ärende
            //vet ej om nedan fungerar 

            //behöver att datum och ordernummer genereras automatiskt, hur?

            var address = AddressService.GetAddressAsync(errand.AddressId);

            if(address != null)
            {
                var errandEntity = new ErrandEntity
                {
                    OrderNumber = errand.OrderNumber,
                    OrderDate = errand.OrderDate,
                    CustomerName = errand.CustomerName,
                    CustomerEmail = errand.CustomerEmail,
                    CustomerPhoneNumber = errand.CustomerPhoneNumber,
                    Description = errand.Description,
                    Status = errand.Status
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
        
        public static async Task AddCommentToErrandAsync(string ordernumber, Errand errand)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == errand.EmployeeId);
            var _errand = await _context.Errands.FirstOrDefaultAsync(x => x.OrderNumber == ordernumber);

            if (employee != null)
            {
                if(_errand != null)
                {
                    var errandDesc = new Errand
                    {
                        Description = errand.Description
                    };

                    _context.Add(errandDesc);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public static async Task UpdateStatusErrandAsync(string ordernumber, Errand errand)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == errand.EmployeeId);
            var _errand = await _context.Errands.FirstOrDefaultAsync(x => x.OrderNumber == ordernumber);

            if(employee != null) // om employee finns gör följande
            {
                if(_errand != null) // om ärendet finns genom ordernummer gör följande
                {
                    if(!string.IsNullOrEmpty(errand.Status))
                        _errand.Status = errand.Status;

                    _context.Update(_errand);
                    await _context.SaveChangesAsync();
                }
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
            return errands;
        }


        // COMMENTS SERVICE /////////////////////////////////////////

        public static async Task SaveCommentAsync(string ordernumber, Comment comment)
        {
            var _errand = await _context.Errands.FirstOrDefaultAsync(x => x.OrderNumber == ordernumber);
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == comment.EmployeeId);

            if (employee != null)
            {
                if (_errand != null)
                {
                    var commentEntity = new CommentEntity
                    {
                        Created = comment.Created,
                        Description = comment.Description
                    };

                    _context.Add(commentEntity);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public static ObservableCollection<Comment> Comments()
        {
            return comments;
        }
    }
}
