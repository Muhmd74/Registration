using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Entities;

namespace Registration.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IBaseRepository<Address> Addresses { get; }
         int Complete();
        Task<int> CompleteAsync();


    }
}
