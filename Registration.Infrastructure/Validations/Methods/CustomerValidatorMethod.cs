using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Registration.Infrastructure.Data.ApplicationDbContext;

namespace Registration.Infrastructure.Validations.Methods
{
    public static class CustomerValidatorMethod
    {
        public static bool IsUniqueEmail(this string email)
        {
            var context = new ApplicationDbContext();
            return !context.Customers.Select(p => p.Email).Contains(email);
        }
    }
}
