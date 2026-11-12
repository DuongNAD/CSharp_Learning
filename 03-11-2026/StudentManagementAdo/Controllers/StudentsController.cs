using Microsoft.AspNetCore.Mvc;
using StudentManagementAdo.Models;
using StudentManagementAdo.Repositories;

namespace StudentManagementAdo.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _repository;

        public StudentsController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Student { DateOfBirth = DateTime.Today.AddYears(-18) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (_repository.CodeExists(student.StudentCode))
            {
                ModelState.AddModelError(nameof(Student.StudentCode), "Mã sinh viên đã tồn tại.");
            }

            if (!ModelState.IsValid)
            {
                return View(student);
            }

            _repository.Add(student);
            TempData["SuccessMessage"] = $"Đã thêm sinh viên \"{student.FullName}\".";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _repository.GetById(id);
            return student == null ? NotFound() : View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            if (_repository.CodeExists(student.StudentCode, student.StudentId))
            {
                ModelState.AddModelError(nameof(Student.StudentCode), "Mã sinh viên đã tồn tại.");
            }

            if (!ModelState.IsValid)
            {
                return View(student);
            }

            if (!_repository.Update(student))
            {
                return NotFound();
            }

            TempData["SuccessMessage"] = $"Đã cập nhật sinh viên \"{student.FullName}\".";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _repository.GetById(id);
            return student == null ? NotFound() : View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_repository.Delete(id))
            {
                TempData["SuccessMessage"] = "Đã xóa sinh viên.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
