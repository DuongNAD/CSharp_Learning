using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieTicketDatabaseFirst.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày giờ chiếu.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày giờ chiếu")]
        public DateTime ShowDate { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên khách hàng từ 3 đến 100 ký tự.")]
        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [RegularExpression(@"^(?:\+84|0)\d{9}$", ErrorMessage = "Số điện thoại không hợp lệ (VD: 0912345678).")]
        [Display(Name = "Số điện thoại")]
        public string CustomerPhone { get; set; } = string.Empty;

        [Display(Name = "Phim")]
        public int MovieId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Số ghế từ 1 đến 10.")]
        [Display(Name = "Số ghế")]
        public int SeatQuantity { get; set; }

        [ValidateNever]
        public virtual Movie? Movie { get; set; }
    }
}
