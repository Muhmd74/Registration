using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Registration.Core.Common.Response;

namespace Registration.Core.Interfaces.BaseInterfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<OutputResponse<bool>> Add(T entity);
        Task<OutputResponse<T>> Update(T entity);
        Task<OutputResponse<bool>> Delete(T entity);
        Task<OutputResponse<IEnumerable<T>>> GetAll(int take=Int32.MaxValue);
        Task<OutputResponse<T>> GetById(Guid id);
        Task<OutputResponse<IEnumerable<T>>> GetAllActive(Expression<Func<T, bool>> match, Expression<Func<T, object>> orderBy = null, int take = Int32.MaxValue

        );
    }
}
