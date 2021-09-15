using System;
using System.Collections.Generic;
using System.Text;
using Registration.Core.Entities;
using Registration.Core.Enums;

namespace Registration.Core.Dtos.Response
{
    public class CustomerDetailsResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
         public string Mobile { get; set; }
         public string ImageUrl { get; set; }
        public DateTime Dob { get; set; }
        public List<AddressDetailsResponse> Addresses { get; set; }
    }
}
