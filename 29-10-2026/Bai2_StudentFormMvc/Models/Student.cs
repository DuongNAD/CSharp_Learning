using System.ComponentModel.DataAnnotations;

namespace Bai2_StudentFormMvc.Models
{
    public class Student
    {
        [Display(Name = "Mã sinh viên")]
        [Required(ErrorMessage = "Vui lòng nhập mã sinh viên")]
        public int Id { get; set; }

        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ và tên sinh viên")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Họ tên phải từ 2 đến 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Tuổi")]
        [Required(ErrorMessage = "Vui lòng nhập tuổi")]
        [Range(16, 60, ErrorMessage = "Tuổi sinh viên phải từ 16 đến 60")]
        public int Age { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ Email")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Lớp học")]
        [Required(ErrorMessage = "Vui lòng nhập tên lớp")]
        public string ClassName { get; set; } = "C2411L";
    }
}
