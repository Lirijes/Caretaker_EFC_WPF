using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caretaker_EFC.MVVM.Models.Entities
{
    public class StatusEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Status { get; set; } = string.Empty;

        public ICollection<ErrandEntity> Errands = new HashSet<ErrandEntity>();
    }
}
