using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caretaker_EFC.MVVM.Models.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        public string? Description { get; set; }

        [Required]
        public string? ErrandOrdernumber { get; set; }
        public ErrandEntity Errand { get; set; } = null!;

        //public int EmployeeIdTwo { get; set; }
        //public EmployeeEntity Employee { get; set; } = null!;
    }
}
