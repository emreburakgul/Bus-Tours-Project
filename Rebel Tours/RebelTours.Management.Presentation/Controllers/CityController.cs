using Microsoft.AspNetCore.Mvc;
using RebelTours.Management.Application.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelTours.Management.Presentation.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Index()
        {

            var cities = _cityService.GetAll();

            return View(cities);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CityDTO city)
        {
            var result = _cityService.Create(city);

            if (result.IsSucceeded)
            {
                return RedirectToAction("Index", "City");
            }
            else
            {
                ViewBag.CommandResult = result;
                return View();
            }

            //try
            //{
            //    _cityService.Create(city);

            //    return RedirectToAction("Index", "City");
            //}
            //catch (Exception)
            //{
            //    ViewBag.ErrorMessage = "Kaydetme sırasında hata meydana geldi";

            //    return View();
            //}
        }

        public IActionResult Update(int id)
        {
            var city = _cityService.GetById(id);

            return View(city);
        }

        [HttpPost]
        public IActionResult Update(CityDTO city)
        {
            try
            {
                _cityService.Update(city);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Güncelleme sırasında hata oldu   {ex.Message}";

                return View();
            }

        }

        public IActionResult Delete(int id)
        {
            var city = _cityService.GetById(id);

            _cityService.Delete(city);

            return RedirectToAction("index");
        }


    }
}
