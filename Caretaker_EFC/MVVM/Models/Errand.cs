using Caretaker_EFC.MVVM.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretaker_EFC.MVVM.Models
{
    internal class Errand
    {
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhoneNumber { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!; // get Id from Address
    }
}
