using System.ComponentModel.DataAnnotations;

namespace MvcHttpDemo.Models
{
    public class Student
    {
        [Display(Name = "Mã SV")]
        public int Id { get; set; }

        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ và tên sinh viên")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Họ tên phải từ 2 đến 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Tuổi")]
        [Required(ErrorMessage = "Vui lòng nhập tuổi")]
        [Range(16, 60, ErrorMessage = "Tuổi phải từ 16 đến 60")]
        public int Age { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress(ErrorMessage = "Định dạng Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Chuyên ngành")]
        [Required(ErrorMessage = "Vui lòng nhập chuyên ngành")]
        public string Major { get; set; } = "Software Engineering";
    }
}
