using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Registration.Core.Entities;
using Registration.Core.Interfaces.BaseInterfaces;

namespace Registration.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _unitOfWork.Customers.GetAll(10);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await _unitOfWork.Customers.Details(id);
            if (model.Success)
            {
                return View(model);
            }

            return Json($"this Item NorFound ");

        }


        public async Task<IActionResult> ChangeActivity(Guid id)
        {
            var model = await _unitOfWork.Customers.ChangeActivity(id);
            if (model.Success)
            {
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");

            }

            return Json($"this Item NorFound ");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _unitOfWork.Customers.GetById(id);
            var model = await _unitOfWork.Customers.Delete(entity.Model);
            if (model.Success)
            {
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");

            }

            return Json($"this Item NorFound ");
        }

        public async Task<IActionResult> IsDefault(Guid id, Guid customerId)
        {
            var model = await _unitOfWork.Addresses.IsDefault(id, customerId);
            if (model.Success)
            {
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Details");

            }

            return Json($"this Item NorFound ");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        public async Task<IActionResult> Create(Customer entity)
        {
            if (!ModelState.IsValid)
            {
                await Create();
            }

            var model = await _unitOfWork.Customers.Add(entity);
            if (model.Success)
            {
                await _unitOfWork.CompleteAsync();

                return RedirectToAction("Index");
            }

            return Json($"this Item NorFound ");

        }
    }
}