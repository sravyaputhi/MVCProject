using Microsoft.AspNetCore.Mvc;

namespace MVCCourse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
