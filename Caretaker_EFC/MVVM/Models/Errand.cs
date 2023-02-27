using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretaker_EFC.MVVM.Models
{
    internal class Errand
    {
        public string OrderNumber { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

    }
}
