using Microsoft.AspNetCore.Mvc;
using PMRentACarII.Areas.Admin.Models;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Extensions;

namespace PMRentACarII.Areas.Admin.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService carService;
        private readonly IAgentService agentService;

        public CarController(ICarService _carService, IAgentService _agentService)
        {
            carService = _carService;
            agentService = _agentService;
        }

        public async Task<IActionResult> Mine()
        {
            var myCars = new MyCarsViewModel();

            var adminId = User.Id();

            myCars.RentedCars = await carService.AllCarsByUserId(adminId);

            var agentId = await agentService.GetAgentId(adminId);

            myCars.AddedCars = await carService.AllCarsByAgentId(agentId);

            return View(myCars);
        }
    }
}
