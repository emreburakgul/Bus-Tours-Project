using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RebelTours.Management.Application.Buses;
using RebelTours.Management.Application.BusModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelTours.Management.Presentation.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusService _busService;
        private readonly IBusModelService _busModelService;

        public BusController(IBusService busService, IBusModelService busModelService)
        {
            _busService = busService;
            _busModelService = busModelService;
        }

        public IActionResult Index()
        {
            var bus = _busService.GetSummary();
            return View(bus);
        }

        public IActionResult Create()
        {
            var busModel = _busModelService.GetAll();
            var busModelsSelect = new SelectList(busModel, "Id", "Name");
            ViewBag.busModel = busModelsSelect;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusDTO bus)
        {
            try
            {
                _busService.Create(bus);

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
            var bus = _busService.GetById(id);
            var busModel = _busModelService.GetAll();
            ViewBag.busManu = new SelectList(busModel, "Id", "Name");
            return View(bus);
        }

        [HttpPost]
        public IActionResult Update(BusDTO bus)
        {
            try
            {
                _busService.Update(bus);

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
            var bus = _busService.GetById(id);
            ViewBag.BusModel = _busModelService.GetById(bus.BusModelId).Name;

            ViewBag.SelectedType = _busService.GetById(bus.Id).SeatMapping;

            return View(bus);
        }

        [HttpPost]
        public IActionResult Delete(BusDTO bus)
        {

            _busService.Delete(bus);

            return RedirectToAction("Index");
        }
    }
}
