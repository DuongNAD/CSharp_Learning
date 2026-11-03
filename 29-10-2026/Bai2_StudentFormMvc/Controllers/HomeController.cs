using Microsoft.AspNetCore.Mvc;

namespace Bai2_StudentFormMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Create", "Student");
        }
    }
}
