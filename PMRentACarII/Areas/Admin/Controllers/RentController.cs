using Microsoft.AspNetCore.Mvc;
using PMRentACarII.Core.Contracts.Admin;

namespace PMRentACarII.Areas.Admin.Controllers
{
    public class RentController : BaseController
    {
        private readonly IRentService rentService;

        public RentController(IRentService _rentService)
        {
            rentService = _rentService;
        }

        public async Task<IActionResult> AllRentsAdmin()
        {
            var model = await rentService.AllRentsAdmin();

            return View(model);
        }
    }
}
