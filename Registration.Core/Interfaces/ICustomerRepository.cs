using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Common.Response;
using Registration.Core.Dtos.Request;
using Registration.Core.Entities;

namespace Registration.Core.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<OutputResponse<bool>> ChangeActivity(Guid id);

        Task<OutputResponse<bool>> UploadImage(CustomerImageRequest model);
    }
}
