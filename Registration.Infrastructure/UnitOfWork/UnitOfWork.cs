using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Entities;
using Registration.Core.Interfaces;
using Registration.Infrastructure.BaseRepository;
using Registration.Infrastructure.Data.ApplicationDbContext;
using Registration.Infrastructure.Repositories.Customers;

namespace Registration.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        public ICustomerRepository Customers { get; private set; }
        public IBaseRepository<Address> Addresses { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Addresses = new BaseRepository<Address>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

     
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
