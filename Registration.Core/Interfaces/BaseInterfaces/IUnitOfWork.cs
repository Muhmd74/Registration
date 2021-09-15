using System;
using System.Threading.Tasks;

namespace Registration.Core.Interfaces.BaseInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IAddressRepository Addresses { get; }
         int Complete();
        Task<int> CompleteAsync();


    }
}
