using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Core.Dtos.Request
{
    public class AddressRequest
    {
        public string Location { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public int PostalCode { get; set; }
        public string Note { get; set; }
        public bool IsDefault { get; set; }
        public Guid CustomerId { get; set; }
    }
}
