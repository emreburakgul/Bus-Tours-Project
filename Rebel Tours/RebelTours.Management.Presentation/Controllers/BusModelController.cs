using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RebelTours.Management.Application.BusManufacturers;
using RebelTours.Management.Application.BusModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelTours.Management.Presentation.Controllers
{
    public class BusModelController : Controller
    {
        private IBusModelService _busModelService;
        private IBusManuService _busManuService;
        public BusModelController(IBusModelService busModelService,IBusManuService busManuService)
        {
            _busModelService = busModelService;
            _busManuService = busManuService;
        }
        

        public IActionResult Index()
        {
            var busModel = _busModelService.GetSummaries();

            return View(busModel);
        }

        public IActionResult Create()
        {
            var busManu = _busManuService.GetAll();
            var busManufacturersSelect = new SelectList(busManu, "Id", "Name");
            ViewBag.busManu = busManufacturersSelect;                  
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusModelDTO busModel)
        {
            try
            {
                _busModelService.Create(busModel);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                ViewBag.Error = "Oluşturma sırasında hata geldi !!";
            }

            return View();
        }

        public IActionResult Update(int id)
        {
            var busModel = _busModelService.GetById(id);
            var busManu = _busManuService.GetAll();
            ViewBag.busManu = new SelectList(busManu, "Id", "Name");            
            return View(busModel);
        }

        [HttpPost]
        public IActionResult Update(BusModelDTO busModel)
        {
            try
            {
                _busModelService.Update(busModel);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                ViewBag.Error = "Oluşturma sırasında hata geldi !!";

                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var busModel = _busModelService.GetById(id);
            ViewBag.BusManu= _busManuService.GetById(busModel.BusManufacturerId).Name;
            ViewBag.SelectedType = _busModelService.GetById(busModel.Id).Type;

            return View(busModel);
        }

        [HttpPost]
        public IActionResult Delete(BusModelDTO busModel)
        {

            _busModelService.Delete(busModel);

            return RedirectToAction("Index");
        }

    }
}
