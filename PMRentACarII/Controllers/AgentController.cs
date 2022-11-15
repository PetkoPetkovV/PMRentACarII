using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMRentACarII.Core.Models.Agent;

namespace PMRentACarII.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        [HttpGet]
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Become(BecomeAgentViewModel model)
        {
            return RedirectToAction("AllCars", "Car");
        }
    }
}
