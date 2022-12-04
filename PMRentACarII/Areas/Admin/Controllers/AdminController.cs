using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PMRentACarII.Areas.Admin.Controllers
{
    
    public class AdminController : HomeController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
