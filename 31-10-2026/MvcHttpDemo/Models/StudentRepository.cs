namespace MvcHttpDemo.Models
{
    /// <summary>
    /// Kho dữ liệu In-Memory quản lý các thao tác CRUD đối tượng Student
    /// </summary>
    public static class StudentRepository
    {
        private static readonly List<Student> _students = new()
        {
            new Student { Id = 1, Name = "Nguyễn Ánh Dương", Age = 20, Email = "duong.nguyen@aptech.edu.vn", Major = "AI & Software Engineering" },
            new Student { Id = 2, Name = "Trần Minh Hoàng", Age = 21, Email = "hoang.tran@aptech.edu.vn", Major = "Fullstack Web Development" },
            new Student { Id = 3, Name = "Lê Thị Thu Hà", Age = 19, Email = "ha.le@aptech.edu.vn", Major = "Data Science" },
            new Student { Id = 4, Name = "Phạm Quốc Bảo", Age = 22, Email = "bao.pham@aptech.edu.vn", Major = "Cloud & DevOps" }
        };

        /// <summary>
        /// Lấy toàn bộ danh sách sinh viên (hỗ trợ tìm kiếm theo từ khóa)
        /// </summary>
        public static List<Student> GetAll(string? keyword = null)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return _students.OrderBy(s => s.Id).ToList();
            }

            return _students
                .Where(s => s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                         || s.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                         || s.Major.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .OrderBy(s => s.Id)
                .ToList();
        }

        /// <summary>
        /// Tìm sinh viên theo Id
        /// </summary>
        public static Student? GetById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Thêm mới sinh viên
        /// </summary>
        public static void Add(Student student)
        {
            student.Id = _students.Any() ? _students.Max(s => s.Id) + 1 : 1;
            _students.Add(student);
        }

        /// <summary>
        /// [BỔ SUNG THEO YÊU CẦU ĐỀ BÀI] Cập nhật / Sửa thông tin sinh viên theo Id
        /// </summary>
        public static bool Update(Student updatedStudent)
        {
            var existing = GetById(updatedStudent.Id);
            if (existing == null)
            {
                return false;
            }

            existing.Name = updatedStudent.Name;
            existing.Age = updatedStudent.Age;
            existing.Email = updatedStudent.Email;
            existing.Major = updatedStudent.Major;
            return true;
        }

        /// <summary>
        /// Xóa sinh viên theo Id
        /// </summary>
        public static bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing == null)
            {
                return false;
            }

            return _students.Remove(existing);
        }
    }
}
