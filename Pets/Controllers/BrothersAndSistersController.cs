using Microsoft.AspNetCore.Mvc;

namespace Pets.Controllers
{
    [Route("/BrothersAndSisters")]
    public class BrothersAndSistersController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/BrothersAndSisters/Index.cshtml");
        }
    }
}
