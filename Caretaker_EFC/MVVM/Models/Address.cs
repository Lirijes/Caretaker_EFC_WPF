namespace Caretaker_EFC.MVVM.Models
{
    internal class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
