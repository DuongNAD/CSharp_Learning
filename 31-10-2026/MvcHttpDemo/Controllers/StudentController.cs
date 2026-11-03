using Microsoft.AspNetCore.Mvc;
using MvcHttpDemo.Models;

namespace MvcHttpDemo.Controllers
{
    public class StudentController : Controller
    {
        // 1. HIỂN THỊ DANH SÁCH SINH VIÊN (GET: /Student hoặc /Student/Index)
        [HttpGet]
        public IActionResult Index(string? search)
        {
            ViewData["CurrentFilter"] = search;
            var students = StudentRepository.GetAll(search);
            return View(students);
        }

        // 2. XEM CHI TIẾT SINH VIÊN (GET: /Student/Details/5)
        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = StudentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // 3. THÊM MỚI SINH VIÊN - HIỂN THỊ FORM (GET: /Student/Create)
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Student());
        }

        // 3. THÊM MỚI SINH VIÊN - XỬ LÝ DỮ LIỆU GỬI LÊN (POST: /Student/Create)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            StudentRepository.Add(student);
            TempData["SuccessMessage"] = $"Đã thêm mới sinh viên \"{student.Name}\" thành công!";
            return RedirectToAction(nameof(Index));
        }

        // =========================================================================
        // 4. [CHỨC NĂNG BỔ SUNG]: SỬA SINH VIÊN (EDIT GET & POST)
        // =========================================================================

        /// <summary>
        /// GET: /Student/Edit/{id}
        /// Bước 1 của luồng Sửa: Tìm sinh viên theo Id và hiển thị lên Form chỉnh sửa
        /// </summary>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = StudentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        /// <summary>
        /// POST: /Student/Edit/{id}
        /// Bước 2 của luồng Sửa: Nhận dữ liệu đã chỉnh sửa từ Form, kiểm tra hợp lệ và cập nhật vào Repository
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(student);
            }

            var updated = StudentRepository.Update(student);
            if (!updated)
            {
                return NotFound();
            }

            TempData["SuccessMessage"] = $"Đã cập nhật thông tin sinh viên \"{student.Name}\" (Mã SV: #{student.Id}) thành công!";
            return RedirectToAction(nameof(Index));
        }

        // 5. XÓA SINH VIÊN - XÁC NHẬN XÓA (GET: /Student/Delete/5)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = StudentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // 5. XÓA SINH VIÊN - THỰC HIỆN XÓA (POST: /Student/Delete/5)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = StudentRepository.GetById(id);
            if (student != null)
            {
                StudentRepository.Delete(id);
                TempData["SuccessMessage"] = $"Đã xóa sinh viên \"{student.Name}\" khỏi danh sách.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
