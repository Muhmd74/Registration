using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registration.Core.Common.Files;
using Registration.Core.Common.Response;
using Registration.Core.Dtos.Request;
using Registration.Core.Dtos.Response;
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

        public async Task<OutputResponse<CustomerDetailsResponse>> Details(Guid id)
        {
            var model = await _context.Customers
                .Include(d=>d.Addresses)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (model != null)
            {
                 return new OutputResponse<CustomerDetailsResponse>()
                {
                    Model = new CustomerDetailsResponse()
                    {
                       Id = model.Id,
                       Dob = model.Dob,
                       Email = model.Email,
                       FirstName = model.FirstName,
                       Gender = model.Gender.ToString(),
                       ImageUrl = model.ImageUrl,
                       LastName = model.LastName,
                       Mobile = model.Mobile,
                       Addresses = model.Addresses.Select(d=>new AddressDetailsResponse()
                       {
                           CityName = d.CityName,
                           CountryName = d.CountryName,
                           IsDefault = d.IsDefault,
                           Location = d.Location,
                           Note = d.Note,
                           PostalCode = d.PostalCode,
                           Id = d.Id
                        }).ToList()
                    },
                    Success = true,
                    Message = ResponseMessages.Success
                };
            }
            return new OutputResponse<CustomerDetailsResponse>()
            {
                Model = null,
                Success = false,
                Message = ResponseMessages.Failure
            };
        }
    }
}
