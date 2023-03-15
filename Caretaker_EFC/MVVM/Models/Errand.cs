using Caretaker_EFC.MVVM.Models.Entities;
using System;

namespace Caretaker_EFC.MVVM.Models
{
    public class Errand
    {
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhoneNumber { get; set; } = string.Empty;
        public string? Description { get; set; }
        //public string Status { get; set; } = string.Empty;

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!; // get Id from Address

        //public Guid EmployeeId { get; set; }
        //public EmployeeEntity Employee { get; set; } = null!;

        public int CommentsId { get; set; }
        public CommentEntity Comment { get; set; } = null!;
    }
}
