using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Common.Response;
using Registration.Core.Const;
using Registration.Infrastructure.Common.Response;

namespace Registration.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<OutputResponse<T>> Add(T entity);
        Task<OutputResponse<T>> Update(T entity);
        Task<OutputResponse<bool>> Delete(T entity);
        Task<OutputResponse<IEnumerable<T>>> GetAll(int take=Int32.MaxValue,int skip=Int32.MaxValue);
        Task<OutputResponse<T>> GetById(Guid id);
        OutputResponse<T> Details(Expression<Func<T, bool>> match, string[] includes = null);

        Task<OutputResponse<IEnumerable<T>>> GetAllActive(Expression<Func<T, bool>> match, Expression<Func<T, object>> orderBy = null, int take = Int32.MaxValue, int skip = Int32.MaxValue

        );
    }
}
