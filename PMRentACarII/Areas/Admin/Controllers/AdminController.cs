using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PMRentACarII.Areas.Admin.Controllers
{
    [Area(AdminConstants.AreaName)]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminConstants.AdminRoleName)]
    public class AdminController : Controller
    {
       
    }
}
