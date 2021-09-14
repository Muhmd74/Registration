using System;

namespace Registration.Core.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public int PostalCode { get; set; }
        public string Note { get; set; }
        public bool IsDefault { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
