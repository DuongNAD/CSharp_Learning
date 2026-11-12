using System.ComponentModel.DataAnnotations;

namespace BookBorrowingCodeFirst.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sách.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Tên sách từ 5 đến 200 ký tự.")]
        [Display(Name = "Tên sách")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập tác giả.")]
        [StringLength(100, ErrorMessage = "Tác giả tối đa 100 ký tự.")]
        [Display(Name = "Tác giả")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập ISBN.")]
        [RegularExpression(@"^(?=(?:[0-9]-?){9}[0-9Xx]$|(?:[0-9]-?){12}[0-9]$)[0-9][0-9Xx-]*$",
            ErrorMessage = "ISBN không đúng định dạng (10 hoặc 13 chữ số, có thể có dấu gạch ngang).")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; } = string.Empty;

        [PublishedYear]
        [Display(Name = "Năm xuất bản")]
        public int PublishedYear { get; set; }

        public virtual ICollection<BorrowingRecord> BorrowingRecords { get; set; } = new List<BorrowingRecord>();
    }
}
