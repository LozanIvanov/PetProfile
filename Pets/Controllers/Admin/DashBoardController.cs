using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Pets.Controllers.Admin
{
   
        [Route("/Admin/Dashboard")]
       // [Authorize(Roles = "Admin,Manager")]
        public class DashBoardController : Controller
        {
            public IActionResult Index()
            {
                return View("~/Views/Admin/Dashboard/Index.cshtml");
            }
        }
    
}
