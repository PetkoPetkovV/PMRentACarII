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
        private readonly IAgentService agentService;
        public DriverController(
            IDriverService _driverService,
            IAgentService _agentService)
        {
            driverService = _driverService;
            agentService = _agentService;
        }

        public async Task<IActionResult> AllDrivers([FromQuery] AllDriversViewModel query)
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

        [HttpGet]
        public async Task<IActionResult> AddDriver()
        {
            if (!(await agentService.ExistsById(User.Id())))
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }
            var model = new DriverModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver(DriverModel model)
        {
            if (!(await agentService.ExistsById(User.Id())))
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            int agentId = await agentService.GetAgentId(User.Id());
            int id = await driverService.CreateDriver(model, agentId);



            return RedirectToAction(nameof(AllDrivers), new { id });
        }
    }
}
