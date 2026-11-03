using Microsoft.AspNetCore.Mvc;

namespace MvcHttpDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Student");
        }
    }
}
