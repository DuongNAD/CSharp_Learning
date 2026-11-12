using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketDatabaseFirst.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên phim.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Tên phim từ 2 đến 200 ký tự.")]
        [Display(Name = "Tên phim")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(0, 1000000000, ErrorMessage = "Giá cơ bản phải lớn hơn hoặc bằng 0.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "Giá cơ bản (VNĐ)")]
        public decimal BasePrice { get; set; }

        [Required]
        [Range(30, 300, ErrorMessage = "Thời lượng từ 30 đến 300 phút.")]
        [Display(Name = "Thời lượng (phút)")]
        public int DurationMinutes { get; set; }

        [Display(Name = "Thể loại")]
        public string? Genre { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
