using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretaker_EFC.MVVM.Models.Entities
{
    internal class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50")]
        public string StreetName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "char(6)")]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = string.Empty;

        [Required]
        public int ErrandId { get; set; }
        public ErrandEntity Errand { get; set; } = null!; // get Id from TaskModel
    }
}
