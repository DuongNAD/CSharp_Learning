using Microsoft.AspNetCore.Mvc;

namespace Bai1_StudentListMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Student");
        }
    }
}
