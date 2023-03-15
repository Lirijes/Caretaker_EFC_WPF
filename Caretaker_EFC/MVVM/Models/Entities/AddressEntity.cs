using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Caretaker_EFC.MVVM.Models.Entities
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string StreetName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "char(6)")]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = string.Empty;

        // since address can have more than 1 errands its an -> one to many relation
        public ICollection<ErrandEntity> Errands = new HashSet<ErrandEntity>();
    }
}
