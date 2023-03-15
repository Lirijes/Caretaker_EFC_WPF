using Caretaker_EFC.MVVM.Models.Entities;

namespace Caretaker_EFC.MVVM.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = string.Empty;

        public string ErrandOrdernumber { get; set; } = null!;
        public ErrandEntity Errand { get; set; } = null!;

    }
}
