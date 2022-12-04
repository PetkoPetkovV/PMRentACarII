using Microsoft.AspNetCore.Mvc;
using PMRentACarII.Areas.Admin;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Models;
using System.Diagnostics;

namespace PMRentACarII.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService carService;

        public HomeController(ICarService _carService)
        {
            carService = _carService;
        }
        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminConstants.AdminRoleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            var model = await carService.NewestCars();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}