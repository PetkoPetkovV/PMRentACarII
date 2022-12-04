using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Models.Car;
using PMRentACarII.Extensions;
using PMRentACarII.Models;
using PMRentACarII.Core.Extensions;

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
            IEnumerable<CarServiceViewModel> myCars;

            var userId = User.Id();

            if (await agentService.ExistsById(userId))
            {
                int agentId = await agentService.GetAgentId(userId);
                myCars = await carService.AllCarsByAgentId(agentId);
            }
            else
            {
                myCars = await carService.AllCarsByUserId(userId);
            }

            return View(myCars);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (await carService.Exists(id) == false)
            {
                return RedirectToAction(nameof(AllCars));
            }

            var model = await carService.CarDetailsById(id);

            if (information != model.GetInformation())
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });

            }

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

            return RedirectToAction(nameof(Details), new { id = id, information = model.GetInformation() });
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await carService.Exists(id) == false)
            {
                return RedirectToAction(nameof(AllCars));
            }

            if (await carService.HasAgentWithId(id, User.Id()) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var car = await carService.CarDetailsById(id);
            var categoryId = await carService.GetCarCategoryId(id);




            var model = new CarModel()
            {
                CarsModel = car.CarsModel,
                Make = car.Make,
                Description = car.Description,
                CategoryId = categoryId,
                ImageUrl = car.ImageUrl,
                PricePerDay = car.PricePerDay,
                SeatCapacity = car.SeatCapacity,
                CarNumber = car.CarNumber,
                Id = id,
                Categories = await carService.GetAllCategories()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (await carService.Exists(model.Id) == false)
            {
                model.Categories = await carService.GetAllCategories();
                ModelState.AddModelError("", "Car does not exist");

                return View();
            }

            if (await carService.HasAgentWithId(model.Id, User.Id()) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (await carService.CategoryExists(model.CategoryId) == false)
            {
                model.Categories = await carService.GetAllCategories();
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await carService.GetAllCategories();

                return View(model);
            }

            await carService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new {id = model.Id, information = model.GetInformation() });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await carService.Exists(id) == false)
            {
                return RedirectToAction(nameof(AllCars));
            }

            if (await carService.HasAgentWithId(id, User.Id()) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var car = await carService.CarDetailsById(id);
            var model = new CarDeletingViewModel()
            {
                Make = car.Make,
                CarsModel = car.CarsModel,
                ImageUrl = car.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CarDeletingViewModel model)
        {
            if (await carService.Exists(id) == false)
            {
                return RedirectToAction(nameof(AllCars));
            }

            if (await carService.HasAgentWithId(id, User.Id()) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await carService.Delete(id);

            return RedirectToAction(nameof(AllCars));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if (await carService.Exists(id) == false)
            {
                return RedirectToAction(nameof(AllCars));
            }

            if (await agentService.ExistsById(User.Id()) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (await carService.IsRented(id))
            {
                return RedirectToAction(nameof(AllCars));
            }

            await carService.Rent(id, User.Id());

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Return(int id)
        {
            if (await carService.Exists(id) == false || (await carService.IsRented(id)) == false)
            {
                return RedirectToAction(nameof(AllCars));
            }

            if (await carService.IsRentedByUserWithId(id, User.Id()) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await carService.Return(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
