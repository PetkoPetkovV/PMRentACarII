using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMRentACarII.Core.Models.Car;

namespace PMRentACarII.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> AllCars()
        {
            var model = new CarsViewModel();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = new CarsViewModel();

            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = new CarDetailsViewModel();

            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarModel model)
        {
            int id = 1;

            return RedirectToAction(nameof(Details), new { id });
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new CarModel();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarModel model)
        {
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(AllCars));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Return(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
