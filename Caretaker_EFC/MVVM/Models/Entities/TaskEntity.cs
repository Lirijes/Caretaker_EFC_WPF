using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretaker_EFC.MVVM.Models.Entities
{
    internal class TaskEntity
    {
        [Key]
        public string OrderNumber { get; set; } = null!;

        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
