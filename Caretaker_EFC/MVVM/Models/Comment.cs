using Caretaker_EFC.MVVM.Models.Entities;
using System;

namespace Caretaker_EFC.MVVM.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string? Description { get; set; }

        public string ErrandOrdernumber { get; set; } = null!;
        public ErrandEntity Errand { get; set; } = null!;

        public Guid EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; } = null!;
    }
}