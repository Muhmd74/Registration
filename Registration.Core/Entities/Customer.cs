using System;
using System.Collections;
using System.Collections.Generic;
using Registration.Core.Enums;

namespace Registration.Core.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Dob { get; set; }
         public ICollection<Address> Addresses { get; set; }
        public DateTime DateTime { get; set; }


    }
}
