using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Registration.Core.Dtos.Request;
using Registration.Core.Entities;
 using Registration.Core.Interfaces.BaseInterfaces;

namespace Registration.Api.Controllers
{

    public class AddressController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost(Routers.Router.Address.Create)]
        public async Task<IActionResult> Create([FromBody] AddressRequest model)
        {
            var result = await _unitOfWork.Addresses.AddAddress(model);
            if (result.Success)
            {
                await _unitOfWork.CompleteAsync();

                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut(Routers.Router.Address.Update)]
        public async Task<IActionResult> Update([FromBody] Address model)
        {
            var result = await _unitOfWork.Addresses.Update(model);
            if (result.Success)
            {
                await _unitOfWork.CompleteAsync();
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut(Routers.Router.Address.IsDefault)]
        public async Task<IActionResult> IsDefault([FromQuery] Guid id, Guid customerId)
        {
            var result = await _unitOfWork.Addresses.IsDefault(id, customerId);
            if (result.Success)
            {
                await _unitOfWork.CompleteAsync();
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut(Routers.Router.Address.Delete)]
        public async Task<IActionResult> Delete([FromBody] Address model)
        {
            var result = await _unitOfWork.Addresses.Delete(model);
            if (result.Success)
            {
                await _unitOfWork.CompleteAsync();
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet(Routers.Router.Address.GetAll)]
        public async Task<IActionResult> GetAll(int take)
        {
            var result = await _unitOfWork.Addresses.GetAll(take);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet(Routers.Router.Address.GetById)]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var result = await _unitOfWork.Addresses.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
