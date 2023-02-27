using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Caretaker_EFC.MVVM.Models.Entities
{
    internal class ErrandEntity
    {

        [Key]
        public string OrderNumber { get; set; } = null!;

        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; }

        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [StringLength(150)]
        public string CustomerEmail { get; set; } = string.Empty;

        [StringLength(13)]
        public string CustomerPhoneNumber { get; set; } = string.Empty;

        public string? Description { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = string.Empty;

        [Required]
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!; // get Id from Address
    }
}
