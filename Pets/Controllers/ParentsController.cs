using Microsoft.AspNetCore.Mvc;

namespace Pets.Controllers
{
    [Route("/Parents")]
    public class ParentsController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Parents/Index.cshtml");
        }
    }
}
