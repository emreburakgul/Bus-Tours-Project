using Microsoft.AspNetCore.Mvc;
using RebelTours.Management.Application.BusManufacturers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelTours.Management.Presentation.Controllers
{
    public class BusManuController : Controller
    {
        private readonly IBusManuService _busManuService;

        public BusManuController(IBusManuService busManuService)
        {
            _busManuService = busManuService;
        }
        public IActionResult Index()
        {
            var busManuDTO = _busManuService.GetAll();

            return View(busManuDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusManuDTO busManu)
        {
            try
            {
                _busManuService.Create(busManu);
                return RedirectToAction("Index");
            }

            catch (Exception)
            {
                ViewBag.ErrorMessage = "Tedarikçi Oluşturulamadı!!!";
                return View();
            }
        }

        public IActionResult Update(int id)
        {
            var busManuDTO = _busManuService.GetById(id);

            return View(busManuDTO);
        }

        [HttpPost]
        public IActionResult Update(BusManuDTO busManuDTO)
        {
            try
            {
                _busManuService.Update(busManuDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Güncelleme sırasında hata oldu. {ex.Message}";
                return View();

            }
        }

        public IActionResult Delete(int id)
        {
            var busManu = _busManuService.GetById(id);                      

            return View(busManu);
        }

        [HttpPost]
        public IActionResult Delete(BusManuDTO busManu)
        {
            _busManuService.Delete(busManu);

            return RedirectToAction("Index");

        }
    }
}
