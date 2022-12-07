using Microsoft.AspNetCore.Mvc;
using PMRentACarII.Core.Contracts.Admin;

namespace PMRentACarII.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        public async Task<IActionResult> AllUsers()
        {
            var model = await userService.AllUsers();

            return View(model);
        }
    }
}
