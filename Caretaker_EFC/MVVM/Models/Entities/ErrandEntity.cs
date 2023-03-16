using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Caretaker_EFC.MVVM.Models.Entities
{
    public class ErrandEntity
    {

        [Key]
        public string OrderNumber { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [StringLength(150)]
        public string CustomerEmail { get; set; } = string.Empty;

        [StringLength(13)]
        public string CustomerPhoneNumber { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!; // get Id from Address

        public int StatusId { get; set; }
        public StatusEntity Status { get; set; } = null!;

        //one to many relationship
        public ICollection<CommentEntity> Comments = new HashSet<CommentEntity>();
    }
}
