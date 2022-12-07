using Microsoft.AspNetCore.Mvc;
using PMRentACarII.Core.Contracts.Admin;

namespace PMRentACarII.Areas.Admin.Controllers
{
    public class DriverController : BaseController
    {
        private readonly IAdminDriverService adminDriverService;

        public DriverController(IAdminDriverService _adminDriverService)
        {
            adminDriverService = _adminDriverService;
        }
        public async Task<IActionResult> AllDrivers()
        {
            var model = await adminDriverService.AllDrivers();

            return View(model);
        }
    }
}
