using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PMRentACarII.Areas.Admin.Controllers
{
    
    public class AdminController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
