using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registration.Core.Common.Response;
using Registration.Core.Interfaces.BaseInterfaces;
using Registration.Infrastructure.Common.Response;
using Registration.Infrastructure.Data.ApplicationDbContext;

namespace Registration.Infrastructure.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OutputResponse<bool>> Add(T entity)
        {
            try
            {
                var model = await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return new OutputResponse<bool>()
                {
                    Model = true,
                    Success = true,
                    Message = ResponseMessages.Success
                };
            }
            catch (Exception e)
            {
                return new OutputResponse<bool>()
                {
                    Model = true,
                    Success = false,
                    Message = e.Message,
                    Errors = new List<ErrorModel>()
                    {
                        new ErrorModel
                        {
                            Message = e.Message,
                            Property = "Exception"
                        },
                        new ErrorModel
                        {
                            Message = e.InnerException?.Message,
                            Property = "Inner Exception"
                        },
                        new ErrorModel
                        {
                            Message = e.Source,
                            Property = "Source"
                        }
                    }

                };
            }

        }

        public async Task<OutputResponse<T>> Update(T entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return new OutputResponse<T>()
                {
                    Model = entity,
                    Success = true,
                    Message = ResponseMessages.Success
                };
            }
            catch (Exception e)
            {
                return new OutputResponse<T>()
                {
                    Model = null,
                    Success = false,
                    Message = e.Message,
                    Errors = new List<ErrorModel>()
                    {
                        new ErrorModel
                        {
                            Message = e.Message,
                            Property = "Exception"
                        },
                        new ErrorModel
                        {
                            Message = e.InnerException?.Message,
                            Property = "Inner Exception"
                        },
                        new ErrorModel
                        {
                            Message = e.Source,
                            Property = "Source"
                        }
                    }

                };
            }

        }
        public async Task<OutputResponse<bool>> Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return new OutputResponse<bool>()
                {
                    Model = true,
                    Success = true,
                    Message = ResponseMessages.Success
                };
            }
            catch (Exception e)
            {
                return new OutputResponse<bool>()
                {
                    Model = false,
                    Success = false,
                    Message = e.Message,
                    Errors = new List<ErrorModel>()
                    {
                        new ErrorModel
                        {
                            Message = e.Message,
                            Property = "Exception"
                        },
                        new ErrorModel
                        {
                            Message = e.InnerException?.Message,
                            Property = "Inner Exception"
                        },
                        new ErrorModel
                        {
                            Message = e.Source,
                            Property = "Source"
                        }
                    }

                };
            }

        }

        public async Task<OutputResponse<IEnumerable<T>>> GetAll(int take = Int32.MaxValue)
        {
            var model = await _context.Set<T>().Take(take).ToListAsync();
            return new OutputResponse<IEnumerable<T>>()
            {
                Model = model,
                Message = ResponseMessages.Success,
                Success = true
            };
        }
        public async Task<OutputResponse<T>> GetById(Guid id)
        {
            var model = await _context.Set<T>().FindAsync(id);

            if (model != null)
            {
                return new OutputResponse<T>
                {
                    Model = model,
                    Message = ResponseMessages.Success,
                    Success = true,
                };
            }
            return new OutputResponse<T>
            {
                Model = null,
                Message = ResponseMessages.NotFound,
                Success = false,
            };
        }

        public OutputResponse<T> Details(Expression<Func<T, bool>> match, string[] includes = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                    return new OutputResponse<T>()
                    {
                        Model = query.FirstOrDefault(match),
                        Message = ResponseMessages.Success,
                        Success = true,
                    };
                }
                return new OutputResponse<T>()
                {
                    Model = null,
                    Message = ResponseMessages.NotFound,
                    Success = false
                };
            }
            catch (Exception e)
            {
                return new OutputResponse<T>()
                {
                    Model = null,
                    Success = false,
                    Message = e.Message,
                    Errors = new List<ErrorModel>()
                   {
                       new ErrorModel
                       {
                           Message = e.Message,
                           Property = "Exception"
                       },
                       new ErrorModel
                       {
                           Message = e.InnerException?.Message,
                           Property = "Inner Exception"
                       },
                       new ErrorModel
                       {
                           Message = e.Source,
                           Property = "Source"
                       }
                   }

                };
            }
        }



        public async Task<OutputResponse<IEnumerable<T>>> GetAllActive(Expression<Func<T, bool>> match, Expression<Func<T, object>> orderBy = null, int take = Int32.MaxValue)
        {
            var model = await _context.Set<T>().Where(match)
                .Take(take)
                .OrderBy(orderBy)
                .ToListAsync();
            return new OutputResponse<IEnumerable<T>>()
            {
                Model = model,
                Message = ResponseMessages.Success,
                Success = true
            };
        }
    }
}
