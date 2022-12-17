using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Models.Agent;
using PMRentACarII.Extensions;

namespace PMRentACarII.Controllers
{
    [Authorize]
    public class AgentController : Controller
        
    {
        /// <summary>
        /// Injectiong agentService
        /// </summary>
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await agentService.ExistsById(User.Id()))
            {
                return BadRequest();
            }

            var model = new BecomeAgentViewModel();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Become(BecomeAgentViewModel model)
        {
            var userId = User.Id();
            var userEmail = model.Email;
            var phoneNumber = model.PhoneNumber;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await agentService.ExistsById(userId))
            {
                return BadRequest();
            }

            if (await agentService.UserWithThatEmailExists(userEmail))
            {
                ModelState.AddModelError(nameof(userEmail), "User with this email already exists!");
            }

            if (await agentService.UserWithPhoneNumberExists(phoneNumber))
            {
                ModelState.AddModelError(nameof(phoneNumber), "User with this phone already exists!");
            }

            await agentService.Create(userId, userEmail, phoneNumber);

            return RedirectToAction("AllCars", "Car");
        }
    }
}
