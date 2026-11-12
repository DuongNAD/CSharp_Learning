using System.ComponentModel.DataAnnotations;

namespace StudentManagementAdo.Models
{
    public class Student : IValidatableObject
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mã sinh viên.")]
        [StringLength(20, ErrorMessage = "Mã sinh viên tối đa 20 ký tự.")]
        [Display(Name = "Mã sinh viên")]
        public string StudentCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Họ tên từ 2 đến 100 ký tự.")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn ngày sinh.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [RegularExpression(@"^(?:\+84|0)\d{9}$", ErrorMessage = "Số điện thoại không hợp lệ (VD: 0912345678 hoặc +84912345678).")]
        [StringLength(15)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.Date >= DateTime.Today)
            {
                yield return new ValidationResult(
                    "Ngày sinh phải nhỏ hơn ngày hiện tại.",
                    new[] { nameof(DateOfBirth) });
            }
        }
    }
}
