using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registration.Core.Common.Files;
using Registration.Core.Common.Response;
using Registration.Core.Dtos.Request;
using Registration.Core.Entities;
using Registration.Core.Interfaces;
using Registration.Infrastructure.BaseRepository;
using Registration.Infrastructure.Common.Response;
using Registration.Infrastructure.Data.ApplicationDbContext;

namespace Registration.Infrastructure.Repositories.Customers
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OutputResponse<bool>> ChangeActivity(Guid id)
        {
            var model = await _context.Customers.FirstOrDefaultAsync(d => d.Id == id);
            if (model != null)
            {
                model.IsActive = !model.IsActive;
                return new OutputResponse<bool>()
                {
                    Model = model.IsActive,
                    Success = true,
                    Message = ResponseMessages.Success
                };
            }
            return new OutputResponse<bool>()
            {
                Model = false,
                Success = false,
                Message = ResponseMessages.NotFound
            };
        }

        public async Task<OutputResponse<bool>> UploadImage(CustomerImageRequest model)
        {
            try
            {
                
                var result = await _context.Customers.FirstOrDefaultAsync(d => d.Id == model.Id);
                if (result != null)
                {
                    result.ImageUrl = model.ImageUrl;

                    return new OutputResponse<bool>()
                    {
                        Model = true,
                        Success = true,
                        Message = ResponseMessages.Success
                    };
                }

                return new OutputResponse<bool>()
                {
                    Model = false,
                    Success = false,
                    Message = ResponseMessages.NotFound
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
    }
}
