using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registration.Core.Common.Response;
using Registration.Core.Dtos.Request;
using Registration.Core.Dtos.Response;
using Registration.Core.Entities;
using Registration.Core.Interfaces;
using Registration.Infrastructure.BaseRepository;
using Registration.Infrastructure.Common.Response;
using Registration.Infrastructure.Data.ApplicationDbContext;

namespace Registration.Infrastructure.Repositories.Addresses
{
    public class AddressRepository : BaseRepository<Address> , IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OutputResponseForValidationFilter> AddAddress(AddressRequest model)
        {
            try
            {
                await _context.Addresses.AddAsync(new Address()
                {
                    CityName = model.CityName,
                    CountryName = model.CountryName,
                    CustomerId = model.CustomerId,
                    Location = model.Location,
                    Note = model.Note,
                    PostalCode = model.PostalCode
                });
                return new OutputResponseForValidationFilter()
                {
                    Model = model,
                    Success = true,
                    Message = ResponseMessages.Success
                };
            }
            catch (Exception e)
            {
               return new OutputResponseForValidationFilter()
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

        public async Task<OutputResponse<bool>> IsDefault(Guid id,Guid customerId)
        {
            var model = await _context.Addresses.FirstOrDefaultAsync(d => d.Id == id);
            var addressDefault = await _context.Addresses.FirstOrDefaultAsync(d=>d.IsDefault);
            if (model!=null)
            {
                addressDefault.IsDefault = false;
                model.IsDefault = true;
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
                Message = ResponseMessages.Failure
            };
        }

        public async Task<OutputResponse<AddressDetailsResponse>> Details(Guid id)
        {
            var model = await _context.Addresses.FirstOrDefaultAsync(d => d.Id == id);
             if (model != null)
            {
                 return new OutputResponse<AddressDetailsResponse>()
                {
                    Model = new AddressDetailsResponse()
                    {
                        IsDefault = model.IsDefault,
                        CityName = model.CityName,
                        CountryName = model.CountryName,
                        Location = model.Location,
                        Note = model.Note,
                        PostalCode = model.PostalCode
                    },
                    Success = true,
                    Message = ResponseMessages.Success
                };
            }
            return new OutputResponse<AddressDetailsResponse>()
            {
                Model = null,
                Success = false,
                Message = ResponseMessages.Failure
            };
        }
    }
}
