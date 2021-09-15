using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Registration.Core.Common.Files;
using Registration.Core.Dtos.Request;
using Registration.Core.Entities;
using Registration.Core.Interfaces;
using Registration.Core.Interfaces.BaseInterfaces;

namespace Registration.Api.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly FileService _fileService;

        public CustomersController(IUnitOfWork  unitOfWork, FileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpPost(Routers.Router.Customer.Create)]
        public async Task<IActionResult> Create([FromBody] Customer model)
        {
            var result = await _unitOfWork.Customers.Add(model);
            if (result.Success)
            {
                await _unitOfWork.CompleteAsync();

                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut(Routers.Router.Customer.Update)]
        public async Task<IActionResult> Update([FromBody] Customer model)
        {
            var result = await _unitOfWork.Customers.Update(model);
            if (result.Success)
            {
              await  _unitOfWork.CompleteAsync();
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut(Routers.Router.Customer.Delete)]
        public async Task<IActionResult> Delete([FromBody] Customer model)
        {
            var result = await _unitOfWork.Customers.Delete(model);
            if (result.Success)
            {
                await _unitOfWork.CompleteAsync();
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet(Routers.Router.Customer.GetAll)]
        public async Task<IActionResult> GetAll(int take)
        {
            var result = await _unitOfWork.Customers.GetAll( take);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet(Routers.Router.Customer.GetById)]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var result = await _unitOfWork.Customers.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.Customer.GetAllActive)]
        public async Task<IActionResult> GetAllActive([FromQuery] int take)
        {
            var result = await _unitOfWork.Customers.GetAllActive(d => d.IsActive,d=>d.DateTime,take);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet(Routers.Router.Customer.Details)]
        public IActionResult Details([FromQuery] Guid id)
        {
            var result = _unitOfWork.Customers.Details(d => d.Id == id, new[] { "addresses" });
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPut(Routers.Router.Customer.ChangeActivity)]
        public async Task<IActionResult> ChangeActivity([FromQuery]Guid id)
        {
            var result = await _unitOfWork.Customers.ChangeActivity(id);
            if (result.Success)
            {
                await _unitOfWork.CompleteAsync();

                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPut(Routers.Router.Customer.Upload)]
        public async Task<IActionResult> Upload([FromForm] CustomerImageRequest model)
        {
            if (model.Image != null)
            {
                model.ImageUrl = _fileService.Upload(model.Image, DirectoryNames.Customer);

            }
            var result = await _unitOfWork.Customers.UploadImage(model);
            if (result.Success)
            {
                await _unitOfWork.CompleteAsync();

                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
