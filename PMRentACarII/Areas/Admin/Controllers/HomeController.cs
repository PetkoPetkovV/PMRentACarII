using Microsoft.AspNetCore.Mvc;

namespace PMRentACarII.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
