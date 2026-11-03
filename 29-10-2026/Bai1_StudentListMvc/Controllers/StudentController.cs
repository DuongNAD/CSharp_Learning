using Microsoft.AspNetCore.Mvc;
using Bai1_StudentListMvc.Models;

namespace Bai1_StudentListMvc.Controllers
{
    public class StudentController : Controller
    {
        // Danh sách sinh viên khởi tạo sẵn theo yêu cầu đề bài: (Id, Name, Age, Email)
        private static readonly List<Student> _students = new()
        {
            new Student { Id = 1, Name = "Nguyễn Ánh Dương", Age = 20, Email = "duong.nguyen@aptech.edu.vn" },
            new Student { Id = 2, Name = "Trần Minh Hoàng", Age = 21, Email = "hoang.tran@aptech.edu.vn" },
            new Student { Id = 3, Name = "Lê Thị Thu Hà", Age = 19, Email = "ha.le@aptech.edu.vn" },
            new Student { Id = 4, Name = "Phạm Quốc Bảo", Age = 22, Email = "bao.pham@aptech.edu.vn" },
            new Student { Id = 5, Name = "Vũ Hoàng Nam", Age = 20, Email = "nam.vu@aptech.edu.vn" }
        };

        /// <summary>
        /// GET: /Student hoặc /Student/Index
        /// Hiển thị toàn bộ danh sách sinh viên lên View
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            // Truyền danh sách Model (List<Student>) sang View Views/Student/Index.cshtml
            return View(_students);
        }
    }
}
