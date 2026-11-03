using System.ComponentModel.DataAnnotations;

namespace Bai1_StudentListMvc.Models
{
    /// <summary>
    /// Model đại diện cho thông tin Sinh viên (Id, Name, Age, Email)
    /// </summary>
    public class Student
    {
        [Display(Name = "Mã SV")]
        public int Id { get; set; }

        [Display(Name = "Họ và Tên")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Tuổi")]
        public int Age { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
    }
}
