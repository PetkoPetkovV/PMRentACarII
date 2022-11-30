using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Models.Driver;
using PMRentACarII.Extensions;
using PMRentACarII.Models;

namespace PMRentACarII.Controllers
{
    [Authorize]
    public class DriverController : Controller
    {
        private readonly IDriverService driverService;
        public DriverController(IDriverService _driverService)
        {
            driverService = _driverService;
        }

        public async Task<IActionResult> AllDrivers([FromQuery]AllDriversViewModel query)
        {
            var result = await driverService.AllDrivers(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllDriversViewModel.DriversPerPage);

            query.TotalDriversCount = result.TotalDrivers;
            query.Drivers = result.Drivers;

            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> Hire(int id)
        {

            await driverService.Hire(id, User.Id());

            return RedirectToAction("Index", "Home");
        }
    }
}
