using Microsoft.AspNetCore.Mvc;
using Bai2_StudentFormMvc.Models;

namespace Bai2_StudentFormMvc.Controllers
{
    public class StudentController : Controller
    {
        // Lưu trữ danh sách sinh viên trong bộ nhớ để vừa hiển thị chi tiết vừa xem toàn bộ danh sách
        private static readonly List<Student> _students = new()
        {
            new Student { Id = 1, Name = "Nguyễn Ánh Dương", Age = 20, Email = "duong.nguyen@aptech.edu.vn", ClassName = "C2411L" }
        };

        /// <summary>
        /// GET: /Student/Index
        /// Hiển thị danh sách toàn bộ sinh viên đã nhập từ Form
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View(_students);
        }

        /// <summary>
        /// GET: /Student/Create
        /// Hiển thị Form nhập liệu thông tin sinh viên
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            var nextId = _students.Any() ? _students.Max(s => s.Id) + 1 : 1;
            return View(new Student { Id = nextId, ClassName = "C2411L" });
        }

        /// <summary>
        /// POST: /Student/Create
        /// Nhận dữ liệu sinh viên từ Form thông qua Model Binding và hiển thị kết quả lên trang web
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            _students.Add(student);
            TempData["SuccessMessage"] = $"Đã tiếp nhận và lưu thông tin sinh viên: {student.Name}!";

            // Hiển thị thông tin sinh viên vừa nhập lên trang Details
            return View("Details", student);
        }

        /// <summary>
        /// GET: /Student/Details/{id}
        /// Hiển thị thông tin chi tiết của 1 sinh viên
        /// </summary>
        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
