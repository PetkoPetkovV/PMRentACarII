using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Models.Car;
using PMRentACarII.Extensions;
using PMRentACarII.Models;

namespace PMRentACarII.Controllers
{
    [Authorize]
    public class CarController : Controller
    {

        private readonly ICarService carService;
        private readonly IAgentService agentService;

        public CarController(
            ICarService _carService,
            IAgentService _agentService)
        {
            carService = _carService;
            agentService = _agentService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllCars([FromQuery]AllCarsViewModel query)
        {
            var result = await carService.AllCars(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarsViewModel.CarsPerPage);

            query.TotalCarsCount = result.TotalCars;
            query.Categories = await carService.AllCategoriesNames();
            query.Cars = result.Cars;

            return View(query);
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
        public async Task<IActionResult> Add()
        {
            if (!(await agentService.ExistsById(User.Id())))
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            var model = new CarModel()
            {
                Categories = await carService.GetAllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarModel model)
        {
            if (!(await agentService.ExistsById(User.Id())))
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }
            if ((await carService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }


            if (!ModelState.IsValid)
            {
                model.Categories = await carService.GetAllCategories();

                return View(model);
            }

            int agentId = await agentService.GetAgentId(User.Id());

            int id = await carService.Create(model, agentId);

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
