using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Caretaker_EFC.MVVM.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)] // there cannot be two identical emails
    internal class EmployeeEntity
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(60)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "char(13)")]
        public string PhoneNumber { get; set; } = string.Empty;

        // since employee can have more than 1 addresses its an -> one to many relation
        public ICollection<AddressEntity> Addresses = new HashSet<AddressEntity>();
    }
}
