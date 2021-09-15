using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Common.Response;
using Registration.Core.Dtos.Request;
using Registration.Core.Entities;
using Registration.Core.Interfaces.BaseInterfaces;

namespace Registration.Core.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<OutputResponseForValidationFilter> AddAddress(AddressRequest model);
        Task<OutputResponse<bool>> IsDefault(Guid id,Guid customerId);
    }
}
