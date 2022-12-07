using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PMRentACarII.Areas.Admin.AdminConstants;

namespace PMRentACarII.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {   
    }
}
