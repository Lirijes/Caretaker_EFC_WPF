using Caretaker_EFC.Contexts;
using Caretaker_EFC.MVVM.Models.Entities;
using Caretaker_EFC.MVVM.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Caretaker_EFC.Services
{
    public static class StatusService
    {
        private static DataContext _context = new DataContext();

        public static ObservableCollection<Status> status = new ObservableCollection<Status>();

        public static async Task SaveStatusAsync(Status status)
        {
            var statusEntity = new StatusEntity
            {
                Id = status.Id,
                Status = status.StatusName
            };

            _context.Add(statusEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Status>> GetAllStatusAsync()
        {
            var _status = new List<Status>();

            foreach (var _statuss in await _context.Status.ToListAsync())
                _status.Add(new Status
                {
                    Id = _statuss.Id,
                    StatusName = _statuss.Status
                });

            return _status;
        }
    }
}
